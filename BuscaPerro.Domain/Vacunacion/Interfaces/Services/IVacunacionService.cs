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
    }
}
