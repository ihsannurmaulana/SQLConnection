using System.Data.SqlClient;

namespace Connection
{
    class Location
    {

        public int id { get; set; }
        public string street_address { get; set; }
        public string postal_code { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string country_id { get; set; }


        // GetAllLocation : Location
        public static List<Location> GetAllLocation()
        {

            SqlConnection conn = MyConnection.Get();
            var location = new List<Location>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_locations";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var loc = new Location();
                        loc.id = reader.GetInt32(0);
                        loc.street_address = reader.GetString(1);
                        loc.postal_code = reader.GetString(2);
                        loc.city = reader.GetString(3);
                        loc.state_province = reader.GetString(4);
                        loc.country_id = reader.GetString(5);

                        location.Add(loc);// Menambahkan objek Location ke dalam list
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
            return location; // Mengembalikan list regions yang berisi objek-objek Region
        }

        public void LocationMenu()
        {
            Menu mMenu = new Menu();
            Console.Clear();
            Console.WriteLine("     All Data Location     ");
            List<Location> locations = Location.GetAllLocation();
            foreach (Location location in locations)
            {

                Console.WriteLine("Id : " + location.id + ", Street Addres : " + location.street_address + ", Postal Code : " + location.postal_code + ", City : " + location.city + ", State Province : " + location.state_province + ", Country ID : " + location.country_id);
            }
            Console.ReadKey();
            mMenu.MainMenu();
        }

    }
}
