using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HorseMarket.Core.Aggregate.Dtos;
using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.Aggregate.Interfaces.Repositories;
using HorseMarket.Core.Aggregate.Interfaces.Services;
using HorseMarket.Core.AuthAggregate.Interfaces;
using HorseMarket.Core.SharedKernel.Interfaces;
using HorseMarket.Core.SharedKernel.Service;

namespace HorseMarket.Application.Services
{
    public class LanceService : BaseService, ILanceService
    {
        private readonly ILanceRepository _lanceRepository;
        private readonly ILoteRepository _loteRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;

        public LanceService(IUnitOfWork unitOfWork, ILanceRepository lanceRepository, ILoteRepository loteRepository,
            IAuthRepository authRepository, IMapper mapper) :
            base(unitOfWork)
        {
            _lanceRepository = lanceRepository;
            _loteRepository = loteRepository;
            _authRepository = authRepository;
            _mapper = mapper;
        }

        public async Task<LanceDto> RealizarLance(LanceDto lanceDto)
        {
            var user = _authRepository.Find(x => x.Id == lanceDto.UserId).FirstOrDefault();
            if (user == null || user.Banido)
            {
                throw new Exception("Id de Usuario invalido!");
            }

            var lote = await _loteRepository.GetLoteWithTracking(lanceDto.LoteId);
            if (lote == null)
            {
                throw new Exception("Id do Lote invalido!");
            }

            if (lanceDto.Valor < await _loteRepository.GetValorLanceAtual(lote.Id))
            {
                throw new Exception("Valor de Lance Invalido!");
            }

            var lance = _mapper.Map<Lance>(lanceDto);
            _lanceRepository.Add(lance);

            if (!Commit())
            {
                throw new Exception("Erro ao salvar o Lance no Banco de Dados!");
            }

            lote.LanceAtualId = lance.Id;
            _loteRepository.Update(lote);

            if (!Commit())
            {
                throw new Exception("Erro ao Editar o Lote no Banco de Dados!");
            }

            return lanceDto;
        }
    }
}
