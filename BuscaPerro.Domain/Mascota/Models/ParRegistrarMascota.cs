using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Mascota.Models
{
    public class ParRegistrarMascota
    {
        public string nombre { get; set; }
        public string sexo { get; set; }
        public string color { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int id_cuenta { get; set; }
        public int id_raza { get; set; }
    }
}
