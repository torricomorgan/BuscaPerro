using Domain.BuscaPerro.Entidad;
using Microsoft.Extensions.Configuration;
using Domain.BuscaPerro.Interfaz.Repository;
using BuscaPerro.Dal.Repository;

namespace DataAccess.BuscaPerro.Repository
{
    public class VacunaRepository : GenericRepository<VacunaEntity> , IVacunaRepository
    {
        public VacunaRepository(IConfiguration configuration) : base(configuration,"vacuna","dbo")
        {

         }
    }
}