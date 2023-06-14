using System.Data.SqlClient;

namespace Connection
{
    class Jobs
    {
        public string id { get; set; }
        public string title { get; set; }
        public int min_salary { get; set; }
        public int max_salary { get; set; }

        // GetAllLocation : Location
        public static List<Jobs> GetAllJob()
        {

            SqlConnection conn = MyConnection.Get();
            var jobs = new List<Jobs>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_m_jobs";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var job = new Jobs();
                        job.id = reader.GetString(0);
                        job.title = reader.GetString(1);
                        job.min_salary = reader.GetInt32(2);
                        job.max_salary = reader.GetInt32(3);

                        jobs.Add(job);// Menambahkan objek Department ke dalam list
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
            return jobs; // Mengembalikan list regions yang berisi objek-objek Region
        }

        public void JobMenu()
        {
            Menu menu = new Menu();
            // GetAll Jobs : Job
            Console.WriteLine("     All Data Jobs\n     ");
            List<Jobs> jobs = Jobs.GetAllJob();
            foreach (Jobs job in jobs)
            {
                Console.WriteLine("");
                Console.WriteLine("ID : " + job.id + ", Title : " + job.title + ", Min Salary : " + job.min_salary + ",  Max Salary : " + job.max_salary);
            }
            Console.ReadKey();
            menu.MainMenu();
        }
    }
}
