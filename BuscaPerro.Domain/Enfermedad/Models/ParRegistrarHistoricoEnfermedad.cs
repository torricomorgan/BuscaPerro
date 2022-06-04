using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Enfermedad.Models
{
    public class ParRegistrarHistoricoEnfermedad
    {
        public string tratamiento_aplicado { get; set; }
        public DateTime fecha { get; set; }
        public int? id_enfermedad { get; set; }
        public int id_mascota { get; set; }
    }
}
