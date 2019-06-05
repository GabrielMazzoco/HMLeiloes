using HorseMarket.Application.Services;
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

            // Repositories
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<DataContext>();
        }
    }
}
