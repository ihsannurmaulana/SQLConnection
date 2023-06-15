using System.Data.SqlClient;

namespace Connection
{
    class Employee
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime hire_date { get; set; }
        public int salary { get; set; }
        public decimal comission { get; set; }
        public int manager_id { get; set; }
        public string job_id { get; set; }
        public int department_id { get; set; }

        // GetAllLocation : Location
        public List<Employee> GetAllEmployee()
        {

            SqlConnection conn = MyConnection.Get();
            var employee = new List<Employee>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_employees";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var emp = new Employee();
                        emp.id = reader.GetInt32(0);
                        emp.first_name = reader.GetString(1);
                        emp.last_name = reader.GetString(2);
                        emp.email = reader.GetString(3);
                        emp.phone_number = reader.GetString(4);
                        emp.hire_date = reader.GetDateTime(5);
                        emp.salary = reader.GetInt32(6);
                        emp.comission = reader.GetDecimal(7);
                        emp.manager_id = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                        emp.job_id = reader.GetString(9);
                        emp.department_id = reader.GetInt32(10);

                        employee.Add(emp);// Menambahkan objek Location ke dalam list
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
            return employee; // Mengembalikan list regions yang berisi objek-objek Region
        }

        public void EmployeeMenu()
        {
            Menu mMenu = new Menu();
            // GetAllEmployee : Employee
            Console.WriteLine("      All Data Employee     ");
            Console.WriteLine("----------------------------");
            List<Employee> employees = GetAllEmployee();
            foreach (Employee employee in employees)
            {

                Console.WriteLine("ID : " + employee.id + ", First Name : " + employee.first_name + ", Last Name : " + employee.last_name + ", Email : " + employee.email + ", Phone Number : " + employee.phone_number + ", Hire Date ID : " + employee.hire_date + ", Salary :  " + employee.salary + ", Comission : " + employee.comission + ", Manager ID : " + employee.manager_id + "Job ID : " + employee.job_id + ", Department ID : " + employee.department_id);
            }
            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
            mMenu.MainMenu();
        }
    }
}
