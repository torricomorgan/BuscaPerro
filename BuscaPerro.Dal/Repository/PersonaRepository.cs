using Domain.BuscaPerro.Entidad;
using Microsoft.Extensions.Configuration;
using Domain.BuscaPerro.Interfaz.Repository;
using BuscaPerro.Dal.Repository;

namespace DataAccess.BuscaPerro.Repository
{
    public class PersonaRepository : GenericRepository<PersonaEntity> , IPersonaRepository
    {
        public PersonaRepository(IConfiguration configuration) : base(configuration,"persona","dbo")
        {

         }
    }
}