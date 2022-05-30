using Domain.BuscaPerro.Entidad;
using Microsoft.Extensions.Configuration;
using Domain.BuscaPerro.Interfaz.Repository;
using BuscaPerro.Dal.Repository;

namespace DataAccess.BuscaPerro.Repository
{
    public class Proveedor_vacunaRepository : GenericRepository<Proveedor_vacunaEntity> , IProveedor_vacunaRepository
    {
        public Proveedor_vacunaRepository(IConfiguration configuration) : base(configuration,"proveedor_vacuna","dbo")
        {

         }
    }
}