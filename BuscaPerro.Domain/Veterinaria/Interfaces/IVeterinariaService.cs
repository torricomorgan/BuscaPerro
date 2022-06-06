using BuscaPerro.Domain.Veterinaria.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Veterinaria.Interfaces
{
    public interface IVeterinariaService
    {
        Task<IEnumerable<UbicacionVeterinariasDTO>> ListarVeterinariasCercanas();
    }
}
