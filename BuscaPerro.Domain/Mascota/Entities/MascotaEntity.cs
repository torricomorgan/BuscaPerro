using System;

namespace BuscaPerro.Domain.Mascota.Entidad
{
    public class MascotaEntity
    {
        public int id_mascota { get; set; }
        public string nombre { get; set; }
        public string sexo { get; set; }
        public string color { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int id_cuenta { get; set; }
        public int id_raza { get; set; }

    }
}