using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Mascota.Entidad;
using BuscaPerro.Domain.Interfaz.Mascota.Repository;

namespace BuscaPerro.Dal.Mascota.Repository
{
    public class RazaRepository : GenericRepository<RazaEntity> , IRazaRepository
    {
        public RazaRepository(IConfiguration configuration) : base(configuration,"raza","dbo")
        {

         }
    }
}