using Domain.BuscaPerro.Entidad;
using Microsoft.Extensions.Configuration;
using Domain.BuscaPerro.Interfaz.Repository;
using BuscaPerro.Dal.Repository;

namespace DataAccess.BuscaPerro.Repository
{
    public class MascotaRepository : GenericRepository<MascotaEntity> , IMascotaRepository
    {
        public MascotaRepository(IConfiguration configuration) : base(configuration,"mascota","dbo")
        {

         }
    }
}