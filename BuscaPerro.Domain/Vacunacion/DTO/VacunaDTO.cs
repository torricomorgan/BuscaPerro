using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Vacunacion.DTO
{
    public class VacunaDTO
    {
        public int id_vacuna { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public float? tiempo_entre_dosis { get; set; }
        public int id_proveedor_vacuna { get; set; }
        public string nombre_proveedor_vacuna { get; set; }
        public string web_proveedor_vacuna { get; set; }

    }
}
