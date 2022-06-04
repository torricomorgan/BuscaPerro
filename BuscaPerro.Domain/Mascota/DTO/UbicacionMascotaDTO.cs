using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Mascota.DTO
{
    public class UbicacionMascotaDTO
    {
        
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string ciudad { get; set; }
        public string departamento { get; set; }
        public string pais { get; set; }

    }
}
