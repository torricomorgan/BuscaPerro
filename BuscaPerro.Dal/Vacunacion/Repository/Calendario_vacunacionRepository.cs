using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Vacunacion.Entidad;
using BuscaPerro.Domain.Interfaz.Vacunacion.Repository;


namespace BuscaPerro.Dal.Vacunacion.Repository
{
    public class Calendario_vacunacionRepository : GenericRepository<Calendario_vacunacionEntity> , ICalendario_vacunacionRepository
    {
        public Calendario_vacunacionRepository(IConfiguration configuration) : base(configuration,"calendario_vacunacion","dbo")
        {

         }
    }
}