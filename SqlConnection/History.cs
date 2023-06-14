using System.Data.SqlClient;

namespace Connection
{
    class History
    {
        public DateTime start_date { get; set; }
        public int employee_id { get; set; }
        public DateTime end_date { get; set; }
        public int department_id { get; set; }
        public string job_id { get; set; }

        // GetAllLocation : Location
        public static List<History> GetAllHistories()
        {

            SqlConnection conn = MyConnection.Get();
            var history = new List<History>();
            try
            {

                // Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM tb_tr_histories";

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var histori = new History();
                        histori.start_date = reader.GetDateTime(0);
                        histori.employee_id = reader.GetInt32(1);
                        histori.end_date = reader.GetDateTime(2);
                        histori.department_id = reader.GetInt32(3);
                        histori.job_id = reader.GetString(4);

                        history.Add(histori);// Menambahkan objek Department ke dalam list
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
            return history; // Mengembalikan list regions yang berisi objek-objek Region
        }

        public void HistoryMenu()
        {
            Menu mMenu = new Menu();

            // GetAllHistoy : Histories
            Console.WriteLine("     All Data Histories     ");
            Console.WriteLine("----------------------------");
            List<History> histories = History.GetAllHistories();
            foreach (History history in histories)
            {

                Console.WriteLine("Employee_ID : " + history.employee_id + ", Start_Date : " + history.start_date + ", End_Date : " + history.end_date + ",  Department ID : " + history.department_id + ", Job_ID : " + history.job_id);
            }
            Console.WriteLine("Press enter to return to the Main Menu");
            Console.ReadKey();
            mMenu.MainMenu();
        }
    }
}
