using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Mascota.Models
{
    public class ParRegistrarPeso
    {
        public float peso { get; set; }
        public DateTime fecha_visita { get; set; }
        public int id_mascota { get; set; }
    }
}
