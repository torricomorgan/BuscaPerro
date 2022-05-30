using Domain.BuscaPerro.Entidad;
using Microsoft.Extensions.Configuration;
using Domain.BuscaPerro.Interfaz.Repository;
using BuscaPerro.Dal.Repository;

namespace DataAccess.BuscaPerro.Repository
{
    public class CuentaRepository : GenericRepository<CuentaEntity> , ICuentaRepository
    {
        public CuentaRepository(IConfiguration configuration) : base(configuration,"cuenta","dbo")
        {

         }
    }
}