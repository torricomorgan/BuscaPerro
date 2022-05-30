using Domain.BuscaPerro.Entidad;
using Microsoft.Extensions.Configuration;
using Domain.BuscaPerro.Interfaz.Repository;
using BuscaPerro.Dal.Repository;

namespace DataAccess.BuscaPerro.Repository
{
    public class Historico_enfermedadesRepository : GenericRepository<Historico_enfermedadesEntity> , IHistorico_enfermedadesRepository
    {
        public Historico_enfermedadesRepository(IConfiguration configuration) : base(configuration,"historico_enfermedades","dbo")
        {

         }
    }
}