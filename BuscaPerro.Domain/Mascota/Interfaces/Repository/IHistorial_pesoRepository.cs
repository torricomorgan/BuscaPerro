using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Mascota.DTO;
using BuscaPerro.Domain.Mascota.Entidad;

namespace BuscaPerro.Domain.Interfaz.Mascota.Repository
{
    public  interface IHistorial_pesoRepository: IGenericRepository<Historial_pesoEntity>
    {
        Task<IEnumerable<HistoricoPesoDTO>> BuscarPesosPorMascota(int idMascota);
    }
}