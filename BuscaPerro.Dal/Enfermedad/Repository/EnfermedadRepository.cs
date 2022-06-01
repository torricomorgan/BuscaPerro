using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Enfermedad.Entidad;
using BuscaPerro.Domain.Interfaz.Enfermedad.Repository;

namespace BuscaPerro.Dal.Enfermedad.Repository
{
    public class EnfermedadRepository : GenericRepository<EnfermedadEntity> , IEnfermedadRepository
    {
        public EnfermedadRepository(IConfiguration configuration) : base(configuration,"enfermedad","dbo")
        {

         }
    }
}