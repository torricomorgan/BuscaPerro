using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Cuenta.DTO
{
    public class CuentaDTO
    {
        public int id_cuenta { get; set; }
        public string usuario { get; set; }
        public int id_persona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string direccion { get; set; }
    }
}
