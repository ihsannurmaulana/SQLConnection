using System.Data.SqlClient;

namespace Connection.Controllers;

public class MenuController
{
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
                        
                    break;
                case 2:
                    new RegionController().Menu();
                    break;
                case 3:
                        
                    break;
                case 4:
                       
                    break;
                case 5:
                        
                    break;
                case 6:
                        
                    break;
                case 7:
                        
                    break;
                case 8:
                        
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