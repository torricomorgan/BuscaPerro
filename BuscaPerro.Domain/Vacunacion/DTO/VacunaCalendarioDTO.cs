using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Vacunacion.DTO
{
    public class VacunaCalendarioDTO
    {
        public int id_calendario_vacunacion { get; set; }
        public int id_vacuna { get; set; }
        public string nombre_vacuna { get; set; }
        public string nombre_mascota { get; set; }
        public DateTime? fecha_aplicada { get; set; }
        public DateTime? fecha_prevista { get; set; }
    }
}
