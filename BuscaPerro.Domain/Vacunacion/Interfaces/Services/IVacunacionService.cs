using BuscaPerro.Domain.Vacunacion.DTO;
using BuscaPerro.Domain.Vacunacion.Entidad;
using BuscaPerro.Domain.Vacunacion.Models;

namespace BuscaPerro.Domain.Vacunacion.Interfaces.Services
{
    public interface IVacunacionService
    {
        Task<IEnumerable<Proveedor_vacunaEntity>> ListarProveedoresVacunas();
        Task<bool> RegistrarVacuna(ParRegistrarVacuna parRegistrarVacuna);
        Task<IEnumerable<VacunaDTO>> ListarVacunas();
        Task<bool> RegistrarVacunaACalendario(ParRegistrarVacunaCalendario parRegistrarVacunaCalendario);
        Task<IEnumerable<VacunaCalendarioDTO>> ListarCalendarioVacunas(int idMascota);
        Task<bool> RegistrarProveedorVacuna(ParRegistrarProveedor parRegistrarProveedor);
        Task<IEnumerable<UbicacionVeterinariasDTO>> ListarVeterinariasCercanas();
    }
}
