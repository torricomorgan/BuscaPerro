using Domain.BuscaPerro.Entidad;
using Microsoft.Extensions.Configuration;
using Domain.BuscaPerro.Interfaz.Repository;
using BuscaPerro.Dal.Repository;

namespace DataAccess.BuscaPerro.Repository
{
    public class Historial_pesoRepository : GenericRepository<Historial_pesoEntity> , IHistorial_pesoRepository
    {
        public Historial_pesoRepository(IConfiguration configuration) : base(configuration,"historial_peso","dbo")
        {

         }
    }
}