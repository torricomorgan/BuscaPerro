using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Vacunacion.Entidad;
using BuscaPerro.Domain.Interfaz.Vacunacion.Repository;
using BuscaPerro.Domain.Vacunacion.DTO;

namespace BuscaPerro.Dal.Vacunacion.Repository
{
    public class VacunaRepository : GenericRepository<VacunaEntity> , IVacunaRepository
    {
        public VacunaRepository(IConfiguration configuration) : base(configuration,"vacuna","dbo")
        {

         }
        public async Task<IEnumerable<VacunaDTO>> ObtenerVacunas()
        {
            string sql = @" select 
                                v.*,
                                pv.nombre AS nombre_proveedor_vacuna,
                                pv.paginaWeb AS web_proveedor_vacuna
                            from dbo.vacuna AS v
                            inner join dbo.proveedor_vacuna AS pv on v.id_proveedor_vacuna = pv.id_proveedor_vacuna;";

            sql = string.Format(sql);
            return await this.Query<VacunaDTO>(sql);
        }
    }
}