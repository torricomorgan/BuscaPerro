using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Mascota.Entidad;
using BuscaPerro.Domain.Interfaz.Mascota.Repository;

namespace BuscaPerro.Dal.Mascota.Repository
{
    public class MascotaRepository : GenericRepository<MascotaEntity> , IMascotaRepository
    {
        public MascotaRepository(IConfiguration configuration) : base(configuration,"mascota","dbo")
        {

         }
    }
}