using AutoMapper;
using HorseMarket.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace HorseMarket.Api.Configuration
{
    public static class MapperInitialize
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToDomainMapping());
                cfg.AddProfile(new DomainToDtoMapping());
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
