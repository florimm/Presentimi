using System.Data;
using System.Data.SqlClient;

namespace Common
{
    public class ConnectionFactory
    {
        public static SqlConnection Connection()
        {
            return new SqlConnection(ConnectionString());
        }

        public static string ConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        }
    }
}
