using BuscaPerro.Domain.Enfermedad.Interfaces.Services;
using BuscaPerro.Domain.Mascota.Interfaces.Services;
using BuscaPerro.Domain.Vacunacion.Interfaces.Services;
using BuscaPerro.Domain.Cuenta.Interfaces.Services;
using BuscaPerro.Service.Cuenta;
using BuscaPerro.Service.Mascota;
using BuscaPerro.Service.Enfermedad;
using BuscaPerro.Service.Vacunacion;
using Microsoft.Extensions.DependencyInjection;


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

            return services;
        }
    }
}
