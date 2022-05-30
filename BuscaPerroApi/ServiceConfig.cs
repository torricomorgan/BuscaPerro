using BuscaPerro.Domain.Interfaces.Services;
using BuscaPerro.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BuscaPerroApi
{
    public static class ServiceConfig
    {
        public static IServiceCollection AddServiceConfig(this IServiceCollection services)
        {
            services.AddScoped<ICuentaService, CuentaService>();

            return services;
        }
    }
}
