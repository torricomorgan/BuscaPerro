using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Vacunacion.Entidad;
using BuscaPerro.Domain.Interfaz.Vacunacion.Repository;
using BuscaPerro.Domain.Vacunacion.DTO;

namespace BuscaPerro.Dal.Vacunacion.Repository
{
    public class Calendario_vacunacionRepository : GenericRepository<Calendario_vacunacionEntity> , ICalendario_vacunacionRepository
    {
        public Calendario_vacunacionRepository(IConfiguration configuration) : base(configuration,"calendario_vacunacion","dbo")
        {

         }
        public async Task<IEnumerable<VacunaCalendarioDTO>> ObtenerVacunasMascota(int idMascota)
        {
            string sql = @" select
                                cv.*,
                                v.nombre AS nombre_vacuna
                            from dbo.calendario_vacunacion AS cv
                            inner join dbo.vacuna AS v on cv.id_vacuna = v.id_vacuna
                            where cv.id_mascota = {0};";

            sql = string.Format(sql, idMascota);
            return await this.Query<VacunaCalendarioDTO>(sql);
        }
    }
}