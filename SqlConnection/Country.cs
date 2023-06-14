using System.Data;
using System.Data.SqlClient;

namespace Connection
{
    class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }


        // GetAllCountry : Country
        public static List<Country> GetAllCountry()
        {
            SqlConnection conn = MyConnection.Get();
            var country = new List<Country>();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_countries";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var con = new Country();
                        con.Id = reader.GetString(0);
                        con.Name = reader.GetString(1);
                        con.RegionId = reader.GetInt32(2);
                        country.Add(con); // Menambahkan objek Region ke dalam list
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
            return country; // Mengembalikan list regions yang berisi objek-objek Region
        }

        // GetCountryByID : Country
        public static List<Country> GetCountryByID(string id)
        {

            SqlConnection conn = MyConnection.Get();
            var countries = new List<Country>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_countries WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Country();
                        country.Id = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        country.RegionId = reader.GetInt32(2);
                        countries.Add(country); // Menambahkan objek Country ke dalam list
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
            return countries; // Mengembalikan list countries yang berisi objek-objek Country
        }

        // Insert Country : Country 
        public static int InsertCountry(string id, string name, int region_id)
        {
            int result = 0;

            SqlConnection conn = MyConnection.Get();
            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "Insert Into tb_m_countries (id, name, region_id) VALUES (@countries_id, @countries_name, @countries_region_id)";
                command.Transaction = transaction;


                // Membuat parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@countries_id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;
                // Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@countries_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;
                // Membuat parameter
                SqlParameter pRegion_Id = new SqlParameter();
                pRegion_Id.ParameterName = "@countries_region_id";
                pRegion_Id.Value = region_id;
                pRegion_Id.SqlDbType = SqlDbType.VarChar;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);
                command.Parameters.Add(pName);
                command.Parameters.Add(pRegion_Id);

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

        // Update country : Country
        public static int UpdateCountry(string id, string newName, int region_id)
        {
            int result = 0;

            SqlConnection conn = MyConnection.Get();
            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "UPDATE tb_m_countries SET id = @id, name = @newName, region_id = @region_id WHERE Id = @id";
                command.Transaction = transaction;

                // Membuat parameter
                SqlParameter pNewName = new SqlParameter();
                pNewName.ParameterName = "@newName";
                pNewName.Value = newName;
                pNewName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;

                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@region_id";
                pRegionId.Value = region_id;
                pRegionId.SqlDbType = SqlDbType.Int;

                // Menambahkan parameter ke command
                command.Parameters.Add(pId);
                command.Parameters.Add(pNewName);
                command.Parameters.Add(pRegionId);

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

        // Delete country : Country
        public static int DeleteCountry(string id)
        {
            int result = 0;

            SqlConnection conn = MyConnection.Get();
            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "DELETE FROM tb_m_countries WHERE Id = @id";
                command.Transaction = transaction;

                // Membuat parameter
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.VarChar;

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

        // Menu
        public void CountryMenu()
        {
            Menu mMenu = new Menu();
            // GetALl Rgeion : Region
            Console.Clear();
            Console.WriteLine("       GetAll Region      ");
            Console.WriteLine("--------------------------");
            List<Country> countries = Country.GetAllCountry();
            foreach (Country country in countries)
            {
                Console.WriteLine("Id : " + country.Id + ", Name : " + country.Name + ", Region ID : " + country.RegionId);
            }

            Console.WriteLine("\n");
            Console.WriteLine("        Menu      ");
            Console.WriteLine("------------------");
            Console.WriteLine("1. GetById");
            Console.WriteLine("2. Insert");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Back");

            try
            {


                Console.Write("Select Menu : ");
                int InputPilihan = int.Parse(Console.ReadLine());

                switch (InputPilihan)
                {
                    case 1:
                        MenuGetByID();
                        break;
                    case 2:
                        InsertMenu();
                        break;
                    case 3:
                        UpdateMenu();
                        break;
                    case 4:
                        DeleteMenu();
                        break;
                    case 5:
                        mMenu.MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        CountryMenu();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MenuGetByID()
        {
            Console.WriteLine("     GetRegionByID      ");
            Console.WriteLine("------------------------");
            Console.Write("Select country By ID : ");
            string id = Console.ReadLine();
            List<Country> countries = Country.GetCountryByID(id);
            foreach (Country country in countries)
            {
                Console.WriteLine("Id : " + country.Id + ", Name : " + country.Name + ", Region ID : " + country.RegionId);
            }
            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
            CountryMenu();
        }
        // Insert Menu
        public void InsertMenu()
        {
            Console.WriteLine("      Insert Country     ");
            Console.WriteLine("-------------------------");
            Console.Write("Add new country id : ");
            string id = Console.ReadLine();
            Console.WriteLine("Add new country name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Add region_id : ");
            int region_id = Convert.ToInt32(Console.ReadLine());

            int isInsertSuccessful = Country.InsertCountry(id, name, region_id);
            if (isInsertSuccessful > 0)
            {
                Console.WriteLine("Data added successfully");
            }
            else
            {
                Console.WriteLine("Data failed to add");
            }
            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
            CountryMenu();
        }

        // Update Menu : Country
        public void UpdateMenu()
        {
            Console.WriteLine("     Update Country      ");
            Console.WriteLine("-------------------------");
            Console.Write("Input the ID of the country to update: ");
            string id = Console.ReadLine();

            Console.Write("Input the new name for the country: ");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter the region ID : ");
            int region_id = int.Parse(Console.ReadLine());

            int updateResult = Country.UpdateCountry(id, newName, region_id);
            if (updateResult > 0)
            {
                Console.WriteLine("Data updated successfully");
            }
            else
            {
                Console.WriteLine("Failed to update data");
            }
            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
            CountryMenu();
        }

        // Delete Menu : Country
        public void DeleteMenu()
        {
            Console.WriteLine("           Delete Country          ");
            Console.WriteLine("-----------------------------------");
            Console.Write("Input the ID of the country to delete: ");
            string id = Console.ReadLine();

            int deleteResult = Country.DeleteCountry(id);
            if (deleteResult > 0)
            {
                Console.WriteLine("Data deleted successfully");
            }
            else
            {
                Console.WriteLine("Failed to delete data");
            }
            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
            CountryMenu();
        }
    }
}
