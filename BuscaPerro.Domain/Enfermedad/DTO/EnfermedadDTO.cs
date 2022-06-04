using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Enfermedad.DTO
{
    public class EnfermedadDTO
    {
        public int id_enfermedad { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
