using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Mascota.DTO
{
    public class HistoricoPesoDTO
    {
        public int id_historial_peso { get; set; }
        public float peso { get; set; }
        public DateTime fecha_visita { get; set; }
    }
}
