using Microsoft.Extensions.Configuration;
using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Mascota.Entidad;
using BuscaPerro.Domain.Interfaz.Mascota.Repository;
using BuscaPerro.Domain.Mascota.DTO;

namespace BuscaPerro.Dal.Mascota.Repository
{
    public class Historial_pesoRepository : GenericRepository<Historial_pesoEntity> , IHistorial_pesoRepository
    {
        public Historial_pesoRepository(IConfiguration configuration) : base(configuration,"historial_peso","dbo")
        {

         }
        public async Task<IEnumerable<HistoricoPesoDTO>> BuscarPesosPorMascota(int idMascota)
        {
            string sql = @" select
                                hp.id_historial_peso,
                                hp.peso,
                                hp.fecha_visita 
                            from dbo.historial_peso AS hp
                            where hp.id_mascota={0};";

            sql = string.Format(sql, idMascota);
            return await this.Query<HistoricoPesoDTO>(sql);
        }
    }
}