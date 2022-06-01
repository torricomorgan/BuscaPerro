using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Mascota.Entidad;
using BuscaPerro.Domain.Interfaz.Mascota.Repository;

namespace BuscaPerro.Dal.Mascota.Repository
{
    public class EspecieRepository : GenericRepository<EspecieEntity> , IEspecieRepository
    {
        public EspecieRepository(IConfiguration configuration) : base(configuration,"especie","dbo")
        {

         }
    }
}