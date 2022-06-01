using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Vacunacion.Models
{
    public class ParRegistrarVacuna
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public float? tiempo_entre_dosis { get; set; }
        public int id_proveedor_vacuna { get; set; }
    }
}
