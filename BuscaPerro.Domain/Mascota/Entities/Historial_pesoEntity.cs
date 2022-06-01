using System;

namespace BuscaPerro.Domain.Mascota.Entidad
{
    public class Historial_pesoEntity
    {
        public int id_historial_peso { get; set; }
        public float peso { get; set; }
        public DateTime fecha_visita { get; set; }
        public int id_mascota { get; set; }

    }
}