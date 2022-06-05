using System.ComponentModel.DataAnnotations;

namespace FormMascota.Dtos
{
    public class RegisterPetsDTO
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public string sexo { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public string fecha_nacimiento { get; set; }
        [Required]
        public int id_cuenta { get; set; }
        [Required]
        public int id_raza { get; set; }

    }
}
