using System.Data.SqlClient;

namespace Connection
{
    public class Menu
    {
        SqlConnection conn = MyConnection.Get();
        Country con = new Country();
        Region reg = new Region();
        Location loc = new Location();
        Jobs jobs = new Jobs();
        Department dept = new Department();
        Employee emp = new Employee();
        History his = new History();


        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("      Main Menu     ");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Countries");
            Console.WriteLine("2. Regions");
            Console.WriteLine("3. Locations");
            Console.WriteLine("4. Jobs");
            Console.WriteLine("5. Departments");
            Console.WriteLine("6. Employees");
            Console.WriteLine("7. Histories");
            Console.WriteLine("8. LINQ");
            Console.WriteLine("9. Exit");
            try
            {
                Console.Write("Select Tabel : ");
                int InputPilihan = Convert.ToInt32(Console.ReadLine());

                switch (InputPilihan)
                {
                    case 1:
                        con.CountryMenu();
                        break;
                    case 2:
                        reg.RegionMenu();
                        break;
                    case 3:
                        loc.LocationMenu();
                        break;
                    case 4:
                        jobs.JobMenu();
                        break;
                    case 5:
                        dept.DepartmentMenu();
                        break;
                    case 6:
                        emp.EmployeeMenu();
                        break;
                    case 7:
                        his.HistoryMenu();
                        break;
                    case 8:
                        new LINQ().Menu();
                        break;
                    case 9:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                Console.ReadKey();
                MainMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
