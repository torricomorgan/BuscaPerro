using Domain.BuscaPerro.Entidad;
using Microsoft.Extensions.Configuration;
using Domain.BuscaPerro.Interfaz.Repository;
using BuscaPerro.Dal.Repository;

namespace DataAccess.BuscaPerro.Repository
{
    public class Calendario_vacunacionRepository : GenericRepository<Calendario_vacunacionEntity> , ICalendario_vacunacionRepository
    {
        public Calendario_vacunacionRepository(IConfiguration configuration) : base(configuration,"calendario_vacunacion","dbo")
        {

         }
    }
}