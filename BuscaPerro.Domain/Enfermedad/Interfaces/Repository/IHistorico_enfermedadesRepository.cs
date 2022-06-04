using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Enfermedad.DTO;
using BuscaPerro.Domain.Enfermedad.Entidad;

namespace BuscaPerro.Domain.Interfaz.Enfermedad.Repository
{
    public  interface IHistorico_enfermedadesRepository: IGenericRepository<Historico_enfermedadesEntity>
    {
        Task<IEnumerable<HistoricoEnfermedadDTO>> ObtenerHistoricoMascota(int idMascota);
    }
}