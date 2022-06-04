using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Enfermedad.DTO
{
    public class HistoricoEnfermedadDTO
    {
        public int id_historico_enfermedades { get; set; }
        public string tratamiento_aplicado { get; set; }
        public DateTime fecha { get; set; }
        public int? id_enfermedad { get; set; }
        public string nombre_enfermedad { get; set; }
    }
}
