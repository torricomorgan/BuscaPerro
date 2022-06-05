namespace FormMascota.Dtos
{
    public class ConnectString
    {
        private readonly IConfiguration configuration1;

        public ConnectString()
        {
        }

        public ConnectString(IConfiguration configuration1)
        {
            this.configuration1 = configuration1;
        }
        
    }
}
