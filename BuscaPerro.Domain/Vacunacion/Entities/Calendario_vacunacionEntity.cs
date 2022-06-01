using System;

namespace BuscaPerro.Domain.Vacunacion.Entidad
{
    public class Calendario_vacunacionEntity
    {
        public int id_calendario_vacunacion { get; set; }
        public DateTime? fecha_aplicada { get; set; }
        public DateTime? fecha_prevista { get; set; }
        public int id_vacuna { get; set; }
        public int id_mascota { get; set; }

    }
}