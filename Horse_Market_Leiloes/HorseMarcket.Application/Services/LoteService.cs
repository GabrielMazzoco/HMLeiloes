using System;
using System.Collections.Generic;
using AutoMapper;
using CloudinaryDotNet;
using HorseMarket.Core.Aggregate.Dtos;
using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.Aggregate.Interfaces.Repositories;
using HorseMarket.Core.Aggregate.Interfaces.Services;
using HorseMarket.Core.SharedKernel.Dtos;
using HorseMarket.Core.SharedKernel.Interfaces;
using HorseMarket.Core.SharedKernel.Service;

namespace HorseMarket.Application.Services
{
    public class LoteService : BaseService, ILoteService
    {
        private readonly ILeilaoRepository _leilaoRepository;
        private readonly ILoteRepository _loteRepository;
        private readonly ILanceRepository _lanceRepository;
        private readonly IFotoService _fotoService;
        private readonly IMapper _mapper;

        public LoteService(IUnitOfWork unitOfWork, ILeilaoRepository leilaoRepository, IMapper mapper,
            ILoteRepository loteRepository, ILanceRepository lanceRepository, IFotoService fotoService) : base(
            unitOfWork)
        {
            _leilaoRepository = leilaoRepository;
            _mapper = mapper;
            _loteRepository = loteRepository;
            _lanceRepository = lanceRepository;
            _fotoService = fotoService;
        }

        public IEnumerable<LoteRegisterDto> GetLotes(int idLeilao)
        {
            var lotes = _loteRepository.GetLotes(idLeilao);

            foreach (var lote in lotes)
            {
                if (lote.LanceAtualId != null)
                {
                    lote.LanceMinimo = _lanceRepository.GetById(lote.LanceAtualId.Value).Valor;
                }
            }

            var lotesToReturn = _mapper.Map<IEnumerable<LoteRegisterDto>>(lotes);

            return lotesToReturn;
        }

        public LoteRegisterDto GetLote(int idLote)
        {
            var lote = _loteRepository.GetLote(idLote);

            if (lote.LanceAtualId != null)
            {
                lote.LanceMinimo = _lanceRepository.GetById(lote.LanceAtualId.Value).Valor;
            }

            var loteToReturn = _mapper.Map<LoteRegisterDto>(lote);

            return loteToReturn;
        }

        public LoteRegisterDto CreateLote(LoteRegisterDto loteRegisterDto)
        {
            var leilao = _leilaoRepository.Any(x => x.Id == loteRegisterDto.LeilaoId);
            if (leilao)
            {
                var lote = _mapper.Map<Lote>(loteRegisterDto);
                var cavalo = _mapper.Map<Cavalo>(loteRegisterDto.Cavalo);

                _loteRepository.AddCavalo(cavalo);

                lote.CavaloId = cavalo.Id;

                _loteRepository.Add(lote);

                loteRegisterDto.Id = lote.Id;

                if (!Commit())
                {
                    throw new Exception("Ocorreu um erro ao salvar no Banco de Dados!");
                }

                return loteRegisterDto;
            }

            return null;
        }

        public bool AddFotoCavalo(FotoForCreationDto fotoForCreationDto, Cloudinary cloudinary, int loteId)
        {
            var fotoAdicionada = _fotoService.AddFotoCavalo(fotoForCreationDto, cloudinary, loteId);

            if (fotoAdicionada)
            {
                if (Commit())
                    return true;
            }

            return false;
        }
    }
}
