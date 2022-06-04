using BuscaPerro.Domain.Autentificacion.DTO;
using BuscaPerro.Domain.Autentificacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Autentificacion.Interfaces
{
    public interface IAutorizacionService
    {
        Task<AutorizacionDTO> IniciarSesion(ParLogIn parLogIn);
    }
}
