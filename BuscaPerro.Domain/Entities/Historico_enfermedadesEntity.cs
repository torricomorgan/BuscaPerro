using System;

namespace Domain.BuscaPerro.Entidad
{
    public class Historico_enfermedadesEntity
    {
        public int id_historico_enfermedades { get; set; }
        public string tratamiento_aplicado { get; set; }
        public DateTime fecha { get; set; }
        public int? id_enfermedad { get; set; }
        public int id_mascota { get; set; }

    }
}