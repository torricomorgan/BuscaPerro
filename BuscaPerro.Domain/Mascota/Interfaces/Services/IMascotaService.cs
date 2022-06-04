using BuscaPerro.Domain.Mascota.DTO;
using BuscaPerro.Domain.Mascota.Entidad;
using BuscaPerro.Domain.Mascota.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Mascota.Interfaces.Services
{
    public interface IMascotaService
    {
        Task<bool> RegistrarMascota(ParRegistrarMascota parRegistrarMascota);
        Task<MascotaDTO> PerfilMascota(int idMascota);
        Task<IEnumerable<RazaEntity>> RetornarRazas(int idEspecie);
        Task<IEnumerable<MascotaDTO>> ListarMascotaPorCuenta(int id_cuenta);
        Task<IEnumerable<EspecieEntity>> RetornarEspecies();
        Task<bool> RegistrarRazas(ParRegistrarRaza parRegistrarRaza);
        Task<bool> RegistrarHistorialPeso(ParRegistrarPeso parRegistrarPeso);
        Task<IEnumerable<HistoricoPesoDTO>> ListarHistorialPesoPorMascota(int idMascota);
    }
}
