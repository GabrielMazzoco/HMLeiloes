using System;
using AutoMapper;
using HorseMarket.Core.Aggregate;
using HorseMarket.Core.Aggregate.Dtos;
using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.AuthAggregate.Dtos;
using HorseMarket.Core.SharedKernel.Dtos;
using HorseMarket.Core.SharedKernel.Entitites;

namespace HorseMarket.Application.AutoMapper
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<UserToCreateDto, User>().AfterMap((src, dest) =>
            {
                dest.Created = DateTime.Now;
                dest.LastActive = DateTime.Now;
                dest.Arrependido = false;
                dest.Banido = false;
                dest.IsAdmin = false;
            });

            CreateMap<LocalizacaoApiDto, Localidade>()
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Localidade))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Uf));

            CreateMap<FotoForCreationDto, Foto>();

            CreateMap<LeilaoToCreateDto, Leilao>();
        }
    }
}
