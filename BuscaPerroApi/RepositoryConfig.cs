using DataAccess.BuscaPerro.Repository;
using Domain.BuscaPerro.Interfaz.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BuscaPerroApi
{
    public static class RepositoryConfig
    {
        public static IServiceCollection AddRepositoryConfig(this IServiceCollection services)
        {
         services.AddTransient<ICalendario_vacunacionRepository,Calendario_vacunacionRepository>();
         services.AddTransient<ICuentaRepository,CuentaRepository>();
         services.AddTransient<IEnfermedadRepository,EnfermedadRepository>();
         services.AddTransient<IEspecieRepository,EspecieRepository>();
         services.AddTransient<IHistorial_pesoRepository,Historial_pesoRepository>();
         services.AddTransient<IHistorico_enfermedadesRepository,Historico_enfermedadesRepository>();
         services.AddTransient<IMascotaRepository,MascotaRepository>();
         services.AddTransient<IPersonaRepository,PersonaRepository>();
         services.AddTransient<IProveedor_vacunaRepository,Proveedor_vacunaRepository>();
         services.AddTransient<IRazaRepository,RazaRepository>();
         services.AddTransient<IVacunaRepository,VacunaRepository>();

            return services;
        }
    }
}