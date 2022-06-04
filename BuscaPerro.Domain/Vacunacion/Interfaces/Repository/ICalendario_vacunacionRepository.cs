using BuscaPerro.Base.Generico.Repositorio;
using BuscaPerro.Domain.Vacunacion.DTO;
using BuscaPerro.Domain.Vacunacion.Entidad;

namespace BuscaPerro.Domain.Interfaz.Vacunacion.Repository
{
    public  interface ICalendario_vacunacionRepository: IGenericRepository<Calendario_vacunacionEntity>
    {
        Task<IEnumerable<VacunaCalendarioDTO>> ObtenerVacunasMascota(int idMascota);
    }
}