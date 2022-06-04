using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Vacunacion.Models
{
    public class ParRegistrarVacunaCalendario
    {
        public DateTime? fecha_aplicada { get; set; }
        public DateTime? fecha_prevista { get; set; }
        public int id_vacuna { get; set; }
        public int id_mascota { get; set; }
    }
}
