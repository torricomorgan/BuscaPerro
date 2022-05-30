using System;

namespace Domain.BuscaPerro.Entidad
{
    public class PersonaEntity
    {
        public int id_persona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string direccion { get; set; }

    }
}