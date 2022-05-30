using Domain.BuscaPerro.Entidad;
using Microsoft.Extensions.Configuration;
using Domain.BuscaPerro.Interfaz.Repository;
using BuscaPerro.Dal.Repository;

namespace DataAccess.BuscaPerro.Repository
{
    public class EnfermedadRepository : GenericRepository<EnfermedadEntity> , IEnfermedadRepository
    {
        public EnfermedadRepository(IConfiguration configuration) : base(configuration,"enfermedad","dbo")
        {

         }
    }
}