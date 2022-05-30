using Domain.BuscaPerro.Entidad;
using Microsoft.Extensions.Configuration;
using Domain.BuscaPerro.Interfaz.Repository;
using BuscaPerro.Dal.Repository;

namespace DataAccess.BuscaPerro.Repository
{
    public class RazaRepository : GenericRepository<RazaEntity> , IRazaRepository
    {
        public RazaRepository(IConfiguration configuration) : base(configuration,"raza","dbo")
        {

         }
    }
}