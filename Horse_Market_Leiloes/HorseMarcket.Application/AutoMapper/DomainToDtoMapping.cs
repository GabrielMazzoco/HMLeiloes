using AutoMapper;
using HorseMarket.Core.Aggregate;
using HorseMarket.Core.Aggregate.Dtos;

namespace HorseMarket.Application.AutoMapper
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Leilao, LeilaoDto>()
                .ForMember(dest => dest.FotoUrl, opt => opt.MapFrom(src => src.Foto.Url));
        }
    }
}
