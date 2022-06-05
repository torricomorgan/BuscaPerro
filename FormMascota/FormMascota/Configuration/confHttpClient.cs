using FormMascota.Repositorios;
using System.Net.Http.Headers;

namespace FormMascota.Configuration
{
    public static class confHttpClient
    {
        public static IHttpClientBuilder AddConfRepositorioHTTP(this IServiceCollection services, ConfigurationManager configuration)
        {

            return services.AddHttpClient<IRepositorio, Repositorio>((serviceProvider, options) =>
            {
                options.BaseAddress = new Uri(configuration["endpoint"]);

            });



        }
    }
}
