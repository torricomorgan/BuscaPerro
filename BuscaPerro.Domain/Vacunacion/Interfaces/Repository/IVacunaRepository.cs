using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Vacunacion.DTO;
using BuscaPerro.Domain.Vacunacion.Entidad;

namespace BuscaPerro.Domain.Interfaz.Vacunacion.Repository
{
    public  interface IVacunaRepository: IGenericRepository<VacunaEntity>
    {
        Task<IEnumerable<VacunaDTO>> ObtenerVacunas();
    }
}