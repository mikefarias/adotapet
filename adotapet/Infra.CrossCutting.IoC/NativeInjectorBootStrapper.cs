using Domain.Entities;
using Domain.Repositories.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;
using Domain.Repositories.Concrete;
using System;

namespace Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            //services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Services
            services.AddTransient<IOngService, OngService>();
            services.AddTransient<IPetService, PetService>();
            services.AddTransient<IAdotanteService, AdotanteService>();

            // Repositories
            services.AddTransient<IOngRepository, OngRepository>();
            services.AddTransient<IPetRepository, PetRepository>();
            services.AddTransient<IAdotanteRepository, AdotanteRepository>();
            services.AddMemoryCache();

        }
    }
}
