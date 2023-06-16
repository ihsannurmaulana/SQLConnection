using System.Data;
using System.Data.SqlClient;
using Connection.Contexts;

namespace Connection.Models;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }

    // GetAllRegion : Region
    public List<Region> GetAll()
    {

        SqlConnection conn = MyConnection.Get();
        conn.Open();
        var region = new List<Region>();
        try
        {

            // Membuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_regions";

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var reg = new Region();
                    reg.Id = reader.GetInt32(0);
                    reg.Name = reader.GetString(1);
                    region.Add(reg); // Menambahkan objek Region ke dalam list
                }
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        conn.Close();
        return region; // Mengembalikan list regions yang berisi objek-objek Region
    }

    // GetRegionByID
    public Region GetByID(int id)
    {

        SqlConnection conn = MyConnection.Get();
        conn.Open();
        
        var reg = new Region();
        try
        {

            // Membuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM tb_m_regions WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) {
                reader.Read();
                
                reg.Id = reader.GetInt32(0);
                reg.Name = reader.GetString(1);
            }
            else {
                reg = new Region();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        conn.Close();
        
        return reg;
    }

    // Insert Region : Region
    public int Insert(string name)
    {
        int result = 0;

        SqlConnection conn = MyConnection.Get();
        conn.Open();
        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            // Membuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "Insert Into tb_m_regions (name) VALUES (@region_name)";
            command.Transaction = transaction;

            // Membuat parameter
            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@region_name";
            pName.Value = name;
            pName.SqlDbType = SqlDbType.VarChar;

            // Menambahkan parameter ke command
            command.Parameters.Add(pName);

            // Menjalankan command
            result = command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }

        conn.Close();
        return result;

    }

    // Update Region : Region
    public int Update(int id, string newName)
    {
        int result = 0;

        SqlConnection conn = MyConnection.Get();
        conn.Open();
        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            // Membuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "UPDATE tb_m_regions SET name = @newName WHERE Id = @id";
            command.Transaction = transaction;

            // Membuat parameter
            SqlParameter pNewName = new SqlParameter();
            pNewName.ParameterName = "@newName";
            pNewName.Value = newName;
            pNewName.SqlDbType = SqlDbType.VarChar;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;

            // Menambahkan parameter ke command
            command.Parameters.Add(pNewName);
            command.Parameters.Add(pId);

            // Menjalankan command
            result = command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }

        conn.Close();
        return result;
    }

    // Delete Region : Region
    public int Delete(int id)
    {
        int result = 0;

        SqlConnection conn = MyConnection.Get();
        conn.Open();
        SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            // Membuat instance untuk command
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "DELETE FROM tb_m_regions WHERE Id = @id";
            command.Transaction = transaction;

            // Membuat parameter
            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.Int;

            // Menambahkan parameter ke command
            command.Parameters.Add(pId);

            // Menjalankan command
            result = command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception rollback)
            {
                Console.WriteLine(rollback.Message);
            }
        }

        conn.Close();
        return result;
    }
}