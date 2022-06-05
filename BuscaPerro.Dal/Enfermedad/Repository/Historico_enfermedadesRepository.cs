using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Enfermedad.Entidad;
using BuscaPerro.Domain.Interfaz.Enfermedad.Repository;
using BuscaPerro.Domain.Enfermedad.DTO;

namespace BuscaPerro.Dal.Enfermedad.Repository
{
    public class Historico_enfermedadesRepository : GenericRepository<Historico_enfermedadesEntity> , IHistorico_enfermedadesRepository
    {
        public Historico_enfermedadesRepository(IConfiguration configuration) : base(configuration,"historico_enfermedades","dbo")
        {

         }
        public async Task<IEnumerable<HistoricoEnfermedadDTO>> ObtenerHistoricoMascota(int idMascota)
        {
            string sql = @" select
                                he.*,
                                e.nombre AS nombre_enfermedad
                            from dbo.historico_enfermedades AS he
                            inner join dbo.enfermedad AS e on he.id_enfermedad = e.id_enfermedad
                            where he.id_mascota = {0};";

            sql = string.Format(sql, idMascota);
            return await this.Query<HistoricoEnfermedadDTO>(sql);
        }
        public async Task<IEnumerable<HistoricoEnfermedadDTO>> ObtenerHistoricoMascotaCuenta(int idCuenta)
        {
            string sql = @" select
                                he.*,
                                e.nombre AS nombre_enfermedad,
                                m.nombre AS nombre_mascota
                            from dbo.historico_enfermedades AS he
                            inner join dbo.enfermedad AS e on he.id_enfermedad = e.id_enfermedad
                            inner join dbo.mascota AS m on he.id_mascota = m.id_mascota
                            where m.id_cuenta = {0};";

            sql = string.Format(sql, idCuenta);
            return await this.Query<HistoricoEnfermedadDTO>(sql);
        }
    }
}