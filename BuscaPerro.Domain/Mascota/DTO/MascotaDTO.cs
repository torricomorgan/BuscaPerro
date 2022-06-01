using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Mascota.DTO
{
    public class MascotaDTO
    {
        public int id_mascota { get; set; }
        public string nombre { get; set; }
        public string sexo { get; set; }
        public string color { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string nombre_dueno { get; set; }
        public string nombre_especie { get; set; }
        public string nombre_raza { get; set; }
    }
}
