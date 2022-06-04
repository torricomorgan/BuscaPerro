using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Mascota.DTO;
using BuscaPerro.Domain.Mascota.Entidad;

namespace BuscaPerro.Domain.Interfaz.Mascota.Repository
{
    public  interface IMascotaRepository: IGenericRepository<MascotaEntity>
    {
        Task<IEnumerable<MascotaDTO>> ObtenerPerfilMascota(int idMascota);
        Task<IEnumerable<MascotaDTO>> ObtenerMascotasPorCuenta(int idCuenta);
    }
}