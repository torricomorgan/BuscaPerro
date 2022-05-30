using System.Data;
using System.Data.SqlClient;


namespace BuscaPerro.Dal.Connection
{
    public class DataBaseConnection
    {
        string cadenaConexion;
        public DataBaseConnection(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }
        private SqlConnection SqlConnection()
        {
            return new SqlConnection(cadenaConexion);
        }
        public IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }
    }
}
