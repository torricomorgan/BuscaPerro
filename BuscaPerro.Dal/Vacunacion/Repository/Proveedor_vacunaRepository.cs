using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Vacunacion.Entidad;
using BuscaPerro.Domain.Interfaz.Vacunacion.Repository;

namespace BuscaPerro.Dal.Vacunacion.Repository
{
    public class Proveedor_vacunaRepository : GenericRepository<Proveedor_vacunaEntity> , IProveedor_vacunaRepository
    {
        public Proveedor_vacunaRepository(IConfiguration configuration) : base(configuration,"proveedor_vacuna","dbo")
        {

         }
    }
}