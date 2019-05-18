using HorseMarket.Core.SharedKernel.Interfaces;
using HorseMarket.Infra.Data;
using HorseMarket.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace HorseMarket.Infra.CrossCutting
{
    public static class Injector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<DataContext>();
        }
    }
}
