using System.Data.SqlClient;

namespace Connection.Contexts;

public class MyConnection
{
    private static string connectionString = "Data Source=CAMOUFLY;Database=db_mcc_79;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
    public static SqlConnection Get()
    {
        return new SqlConnection(connectionString);
    }
}