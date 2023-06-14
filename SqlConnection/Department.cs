using System.Data.SqlClient;

namespace Connection
{
    class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        public int location_id { get; set; }
        public int manager_id { get; set; }

        // GetAllLocation : Location
        public static List<Department> GetAllDepartment()
        {

            SqlConnection conn = MyConnection.Get();
            var department = new List<Department>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_departments";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var dep = new Department();
                        dep.id = reader.GetInt32(0);
                        dep.name = reader.GetString(1);
                        dep.location_id = reader.GetInt32(2);
                        dep.manager_id = reader.GetInt32(3);

                        department.Add(dep);// Menambahkan objek Department ke dalam list
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
            return department; // Mengembalikan list regions yang berisi objek-objek Region
        }

        // Menu 
        public void DepartmentMenu()
        {
            Menu mMenu = new Menu();
            // GetAllDepartment : Department
            Console.Clear();
            Console.WriteLine("     All Data Department     ");
            List<Department> departments = Department.GetAllDepartment();
            foreach (Department department in departments)
            {

                Console.WriteLine("Id : " + department.id + ", Department Name : " + department.name + ", Location ID : " + department.location_id + ", Manager ID : " + department.manager_id);
            }

            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
            mMenu.MainMenu();
        }
    }
}
