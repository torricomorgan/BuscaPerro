using BuscaPerro.Domain.Enfermedad.DTO;
using BuscaPerro.Domain.Enfermedad.Entidad;
using BuscaPerro.Domain.Enfermedad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Enfermedad.Interfaces.Services
{
    public interface IEnfermedadService
    {
        Task<bool> RegistrarEnfermedad(ParRegistrarEnfermedad parRegistrarEnfermedad);
        Task<bool> RegistrarEnfermedadHistorico(ParRegistrarHistoricoEnfermedad parRegistrarHistoricoEnfermedad);
        Task<IEnumerable<HistoricoEnfermedadDTO>> ListarHistoricoEnfermedadPorMascota(int idMascota);
        Task<IEnumerable<HistoricoEnfermedadDTO>> ListarHistoricoEnfermedadPorCuenta(int idCuenta);
        Task<IEnumerable<EnfermedadEntity>> ListarEnfermedades();
    }
}
