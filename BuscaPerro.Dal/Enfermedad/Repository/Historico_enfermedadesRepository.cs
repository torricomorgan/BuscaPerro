using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Enfermedad.Entidad;
using BuscaPerro.Domain.Interfaz.Enfermedad.Repository;

namespace BuscaPerro.Dal.Enfermedad.Repository
{
    public class Historico_enfermedadesRepository : GenericRepository<Historico_enfermedadesEntity> , IHistorico_enfermedadesRepository
    {
        public Historico_enfermedadesRepository(IConfiguration configuration) : base(configuration,"historico_enfermedades","dbo")
        {

         }
    }
}