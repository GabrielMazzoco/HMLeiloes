using System.Linq;
using AutoMapper;
using HorseMarket.Core.Aggregate;
using HorseMarket.Core.Aggregate.Dtos;
using HorseMarket.Core.Aggregate.Entities;

namespace HorseMarket.Application.AutoMapper
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Leilao, LeilaoDto>()
                .ForMember(dest => dest.FotoUrl, opt => opt.MapFrom(src => src.Foto.Url));

            CreateMap<Lote, LoteRegisterDto>();

            CreateMap<Cavalo, CavaloDto>()
                .ForMember(dest => dest.FotoUrl, opt => opt.MapFrom(src => src.Fotos.First().Url)); 
        }
    }
}
