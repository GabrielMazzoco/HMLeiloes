using HorseMarket.Application.Services;
using HorseMarket.Core.Aggregate.Interfaces.Repositories;
using HorseMarket.Core.Aggregate.Interfaces.Services;
using HorseMarket.Core.AuthAggregate.Interfaces;
using HorseMarket.Core.SharedKernel.Interfaces;
using HorseMarket.Infra.Data;
using HorseMarket.Infra.Data.Repositories;
using HorseMarket.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace HorseMarket.Infra.CrossCutting
{
    public static class Injector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ILeilaoService, LeilaoService>();
            services.AddScoped<IFotoService, FotoService>();
            services.AddScoped<ILoteService, LoteService>();

            // Repositories
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ILeilaoRepository, LeilaoRepository>();
            services.AddScoped<IFotoRepository, FotoRepository>();
            services.AddScoped<ILoteRepository, LoteRepository>();

            services.AddScoped<DataContext>();
        }
    }
}
