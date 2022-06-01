using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Mascota.Entidad;
using BuscaPerro.Domain.Interfaz.Mascota.Repository;

namespace BuscaPerro.Dal.Mascota.Repository
{
    public class Historial_pesoRepository : GenericRepository<Historial_pesoEntity> , IHistorial_pesoRepository
    {
        public Historial_pesoRepository(IConfiguration configuration) : base(configuration,"historial_peso","dbo")
        {

         }
    }
}