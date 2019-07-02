using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using HorseMarket.Core.Aggregate;
using HorseMarket.Core.Aggregate.Dtos;
using HorseMarket.Core.Aggregate.Interfaces.Repositories;
using HorseMarket.Core.Aggregate.Interfaces.Services;
using HorseMarket.Core.SharedKernel.Dtos;
using HorseMarket.Core.SharedKernel.Interfaces;
using HorseMarket.Core.SharedKernel.Service;

namespace HorseMarket.Application.Services
{
    public class LeilaoService : BaseService, ILeilaoService
    {
        private readonly ILeilaoRepository _leilaoRepository;
        private readonly IFotoService _fotoService;
        private readonly IMapper _mapper;

        public LeilaoService(IUnitOfWork unitOfWork, ILeilaoRepository leilaoRepository, IFotoService fotoService, IMapper mapper) :
            base(unitOfWork)
        {
            _leilaoRepository = leilaoRepository;
            _fotoService = fotoService;
            _mapper = mapper;
        }

        public int CreateLeilao(LeilaoToCreateDto leilaoToCreateDto)
        {
            if (leilaoToCreateDto.Inicio.Date > leilaoToCreateDto.Fim.Date ||
                leilaoToCreateDto.Fim.Day - leilaoToCreateDto.Inicio.Day < 7)
            {
                throw new Exception("Periodo de Vigencia do Leilao invalido!");
            }

            var leilao = _leilaoRepository.Find(x => x.Nome == leilaoToCreateDto.Nome).FirstOrDefault();

            if (leilao != null)
            {
                throw new Exception("Ja existe um Leilao com esse Nome!");
            }

            leilao = _mapper.Map<Leilao>(leilaoToCreateDto);

            _leilaoRepository.Add(leilao);

            if (!Commit())
                throw new Exception("Houve algum erro ao tentar salvar no Banco de Dados!");

            return leilao.Id;
        }

        public bool AddFotoLeilao(FotoForCreationDto fotoForCreationDto, Cloudinary cloudinary)
        {
            var fotoId = _fotoService.AddFotoLeilao(fotoForCreationDto, cloudinary);

            var leilao = _leilaoRepository.Find(x => x.Id == fotoForCreationDto.LeilaoId).FirstOrDefault();

            if (leilao != null)
            {
                leilao.FotoId = fotoId;

                _leilaoRepository.Update(leilao);

                if (Commit())
                    return true;
            }

            return false;
        }

        public async Task<IEnumerable<LeilaoDto>> GetLeiloes()
        {
            var leiloes = await _leilaoRepository.GetLeiloes();

            if (IsNotNullOrEmpty(leiloes))
            {
                var leiloesToReturn = _mapper.Map<IEnumerable<LeilaoDto>>(leiloes);

                return leiloesToReturn;
            }

            return null;
        }

        public async Task<LeilaoDto> GetLeilao(int idLeilao)
        {
            var leiloes = await _leilaoRepository.GetLeilao(idLeilao);

            if (leiloes != null)
            {
                var leilaoToReturn = _mapper.Map<LeilaoDto>(leiloes);

                return leilaoToReturn;
            }

            return null;
        }
    }
}
