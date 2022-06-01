using BuscaPerro.Domain.Cuenta.DTO;
using BuscaPerro.Domain.Cuenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Cuenta.Interfaces.Services
{
    public interface ICuentaService
    {
        Task<bool> RegistrarCuenta(ParRegistrarCuenta parRegistrarCuenta);
        Task<CuentaDTO> RetornarPerfilCuenta(int idCuenta);
    }
}
