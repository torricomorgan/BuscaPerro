using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Cuenta.Entidad;
using BuscaPerro.Domain.Interfaz.Cuenta.Repository;

namespace BuscaPerro.Dal.Cuenta.Repository
{
    public class PersonaRepository : GenericRepository<PersonaEntity> , IPersonaRepository
    {
        public PersonaRepository(IConfiguration configuration) : base(configuration,"persona","dbo")
        {

         }
    }
}