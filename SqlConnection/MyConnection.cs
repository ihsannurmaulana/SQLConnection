using System.Data.SqlClient;

namespace Connection
{
    public class MyConnection
    {
        static string connectionString = "Data Source=CAMOUFLY;Database=db_mcc_79;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        static SqlConnection connection;
        public static SqlConnection Get()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
