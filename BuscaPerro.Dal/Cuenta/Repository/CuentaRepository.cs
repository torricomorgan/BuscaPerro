using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Cuenta.Entidad;
using BuscaPerro.Domain.Interfaz.Cuenta.Repository;

namespace BuscaPerro.Dal.Cuenta.Repository
{
    public class CuentaRepository : GenericRepository<CuentaEntity> , ICuentaRepository
    {
        public CuentaRepository(IConfiguration configuration) : base(configuration,"cuenta","dbo")
        {

         }
    }
}