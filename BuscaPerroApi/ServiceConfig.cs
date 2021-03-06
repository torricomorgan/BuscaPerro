using BuscaPerro.Domain.Enfermedad.Interfaces.Services;
using BuscaPerro.Domain.Mascota.Interfaces.Services;
using BuscaPerro.Domain.Vacunacion.Interfaces.Services;
using BuscaPerro.Domain.Cuenta.Interfaces.Services;
using BuscaPerro.Domain.Autentificacion.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using BuscaPerro.Domain.Cuenta.Services;
using BuscaPerro.Domain.Mascota.Services;
using BuscaPerro.Domain.Enfermedad.Services;
using BuscaPerro.Domain.Vacunacion.Services;
using BuscaPerro.Domain.Autotentificacion.Services;
using BuscaPerro.Domain.Veterinaria.Interfaces;
using BuscaPerro.Domain.Veterinaria.Services;

namespace BuscaPerroApi
{
    public static class ServiceConfig
    {
        public static IServiceCollection AddServiceConfig(this IServiceCollection services)
        {
            services.AddScoped<ICuentaService, CuentaService>();
            services.AddScoped<IMascotaService, MascotaService>();
            services.AddScoped<IEnfermedadService, EnfermedadService>();
            services.AddScoped<IVacunacionService, VacunacionService>();
            services.AddScoped<IAutorizacionService, AutorizacionService>();
            services.AddScoped<IVeterinariaService, VeterinariaService>();

            return services;
        }
    }
}
