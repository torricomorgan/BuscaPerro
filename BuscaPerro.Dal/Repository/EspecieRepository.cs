using Domain.BuscaPerro.Entidad;
using Microsoft.Extensions.Configuration;
using Domain.BuscaPerro.Interfaz.Repository;
using BuscaPerro.Dal.Repository;

namespace DataAccess.BuscaPerro.Repository
{
    public class EspecieRepository : GenericRepository<EspecieEntity> , IEspecieRepository
    {
        public EspecieRepository(IConfiguration configuration) : base(configuration,"especie","dbo")
        {

         }
    }
}