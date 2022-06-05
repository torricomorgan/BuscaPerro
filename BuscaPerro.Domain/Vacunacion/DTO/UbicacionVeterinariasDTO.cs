using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Vacunacion.DTO
{
    public class UbicacionVeterinariasDTO
    {
        public string business_status { get; set; }
        public string name { get; set; }
        public float rating { get; set; }
        public int user_ratings_total { get; set; }
        public string vicinity { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
    }
}
