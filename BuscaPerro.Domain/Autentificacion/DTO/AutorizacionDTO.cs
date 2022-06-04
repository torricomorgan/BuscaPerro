using BuscaPerro.Domain.Cuenta.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Autentificacion.DTO
{
    public class AutorizacionDTO
    {
        public bool exito { get; set; }
        public string token { get; set; }
        public int id_cuenta { get; set; }
        public int id_persona { get; set; }
    }

}
