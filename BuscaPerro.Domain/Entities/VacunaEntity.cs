namespace Domain.BuscaPerro.Entidad
{
    public class VacunaEntity
    {
        public int id_vacuna { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string proveedor { get; set; }
        public float? tiempo_entre_dosis { get; set; }
        public int id_proveedor_vacuna { get; set; }

    }
}