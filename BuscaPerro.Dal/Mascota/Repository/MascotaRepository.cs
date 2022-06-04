using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Mascota.Entidad;
using BuscaPerro.Domain.Interfaz.Mascota.Repository;
using BuscaPerro.Domain.Mascota.DTO;

namespace BuscaPerro.Dal.Mascota.Repository
{
    public class MascotaRepository : GenericRepository<MascotaEntity> , IMascotaRepository
    {
        public MascotaRepository(IConfiguration configuration) : base(configuration,"mascota","dbo")
        {

         }

        public async Task<IEnumerable<MascotaDTO>> ObtenerPerfilMascota(int idMascota)
        {
            string sql = @" select 
                                m.*,
                                r.nombre AS nombre_raza,
                                e.nombre_comun AS nombre_especie,
                                CONCAT(p.nombre, ' ' ,p.apellido) AS nombre_dueno
                            from dbo.mascota AS m
                            inner join dbo.raza AS r on m.id_raza = r.id_raza
                            inner join dbo.especie AS e on r.id_especie = e.id_especie
                            inner join dbo.cuenta AS c on m.id_cuenta = c.id_cuenta
                            inner join dbo.persona AS p on c.id_persona = p.id_persona
                            where m.id_mascota = {0};";

            sql = string.Format(sql, idMascota);
            return await this.Query<MascotaDTO>(sql);
        }
        public async Task<IEnumerable<MascotaDTO>> ObtenerMascotasPorCuenta(int idCuenta)
        {
            string sql = @" select 
                                m.*,
                                r.nombre AS nombre_raza,
                                e.nombre_comun AS nombre_especie,
                                CONCAT(p.nombre, ' ' ,p.apellido) AS nombre_dueno
                            from dbo.mascota AS m
                            inner join dbo.raza AS r on m.id_raza = r.id_raza
                            inner join dbo.especie AS e on r.id_especie = e.id_especie
                            inner join dbo.cuenta AS c on m.id_cuenta = c.id_cuenta
                            inner join dbo.persona AS p on c.id_persona = p.id_persona
                            where m.id_cuenta = {0};";

            sql = string.Format(sql, idCuenta);
            return await this.Query<MascotaDTO>(sql);
        }
    }
}