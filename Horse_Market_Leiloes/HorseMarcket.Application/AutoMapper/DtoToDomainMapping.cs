using System;
using AutoMapper;
using HorseMarket.Core.Aggregate.Entities;
using HorseMarket.Core.AuthAggregate.Dtos;

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
        }
    }
}
