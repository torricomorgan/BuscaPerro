using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Veterinaria.DTO
{
    public class UbicacionVeterinariasDTO
    {
        public string estado { get; set; }
        public string nombre { get; set; }
        public float calificacion { get; set; }
        public int calificacion_usuarios { get; set; }
        public string ubicacion { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }
}
