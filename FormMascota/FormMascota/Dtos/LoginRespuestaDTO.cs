namespace FormMascota.Dtos
{
    public class LoginRespuestaDTO
    {
        public bool exito { get; set; }
        public string token { get; set; }
        public int id_cuenta { get; set; }
        public int id_persona { get; set; }
    }
}
