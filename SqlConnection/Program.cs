
using Connection;
new Menu().MainMenu();
;/*namespace Connection
{
    public class Program
    {
        //Connection Global

        public static void Main(string[] args)
        {

            // GetAll : Region
            *//*List<Region> regions = Region.GetAllRegion();
            foreach (Region region in regions)
            {
                Console.WriteLine("Id : " + region.Id + ", Name : " + region.Name);
            }*//*

            // GetRegionByID : Region
            *//*Console.WriteLine("     GetRegionByID      ");
            Console.Write("Select region By ID : ");
            int id = int.Parse(Console.ReadLine());
            List<Region> regions = Region.GetRegionByID(id);
            foreach (Region region in regions)
            {
                Console.WriteLine("Id : " + region.Id + ", Name : " + region.Name);
            }*//*

            // Insert new region 
            *//*Console.WriteLine("     Insert      ");
            Console.Write("Add new region : ");
            string name = Console.ReadLine();
            int isInsertSuccessful = InsertRegion(name);
            if (isInsertSuccessful > 0)
            {
                Console.WriteLine("Data added successfully");
            }
            else
            {
                Console.WriteLine("Data failed to add");
            }*//*

            // Update Region : Region
            *//*Console.WriteLine("     Update Region       ");
            Console.Write("Enter the ID of the region to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter the new name for the region: ");
            string newName = Console.ReadLine();

            int updateResult = Region.UpdateRegion(id, newName);
            if (updateResult > 0)
            {
                Console.WriteLine("Data updated successfully");
            }
            else
            {
                Console.WriteLine("Failed to update data");
            }*//*

            // Delete Region
            *//*Console.Write("Enter the ID of the region to delete: ");
            int id = int.Parse(Console.ReadLine());

            int deleteResult = Region.DeleteRegion(id);
            if (deleteResult > 0)
            {
                Console.WriteLine("Data deleted successfully");
            }
            else
            {
                Console.WriteLine("Failed to delete data");
            }*//*

            // GetAllCountry : Country
            *//*List<Country> countries = Country.GetAllCountry();
            foreach (Country country in countries)
            {
                Console.WriteLine("Id : " + country.Id + ", Name : " + country.Name + ", Region ID : " + country.RegionId);
            }*//*

            // GetCountryByID
            *//*Console.WriteLine("     GetCountryByID      ");
            Console.Write("Select country By ID : ");
            string id = Console.ReadLine();
            List<Country> countries = Country.GetCountryByID(id);
            foreach (Country country in countries)
            {
                Console.WriteLine("Id : " + country.Id + ", Name : " + country.Name + ", Region ID : " + country.RegionId);
            }*//*

            // Insert new country 
            *//*Console.WriteLine("     Insert      ");
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
            }*//*

            // Update Country : Country
            *//*Console.WriteLine("     Update Country       ");
            Console.Write("Enter the ID of the country to update: ");
            string id = Console.ReadLine();

            Console.Write("Enter the new name for the region: ");
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
            }*//*

            // Delete Country
            *//*Console.Write("Enter the ID of the region to delete: ");
            string id = Console.ReadLine();

            int deleteResult = Country.DeleteCountry(id);
            if (deleteResult > 0)
            {
                Console.WriteLine("Data deleted successfully");
            }
            else
            {
                Console.WriteLine("Failed to delete data");
            }*//*

            // GetAllLocation : Location
            *//*Console.WriteLine("     All Data Location     ");
            List<Location> locations = Location.GetAllLocation();
            foreach (Location location in locations)
            {

                Console.WriteLine("Id : " + location.id + ", Street Addres : " + location.street_address + ", Postal Code : " + location.postal_code + ", City : " + location.city + ", State Province : " + location.state_province + ", Country ID : " + location.country_id);
            }*//*

            // GetAllEmployee : Employee
            *//*Console.WriteLine("     All Data Employee     ");
            List<Employee> employees = Employee.GetAllEmployee();
            foreach (Employee employee in employees)
            {

                Console.WriteLine("Id : " + employee.id + ", First Name : " + employee.first_name + ", Last Name : " + employee.last_name + ", Email : " + employee.email + ", Phone Number : " + employee.phone_number + ", Hire Date ID : " + employee.hire_date + ", Salary :  " + employee.salary + ", Comission : " + employee.comission + ", Manager ID : " + employee.manager_id + "Job ID : " + employee.job_id + ", Department ID : " + employee.department_id);
            }*//*

            // GetAllDepartment : Department
            *//*Console.WriteLine("     All Data Department     ");
            List<Department> departments = Department.GetAllDepartment();
            foreach (Department department in departments)
            {

                Console.WriteLine("Id : " + department.id + ", Department Name : " + department.name + ", Location ID : " + department.location_id + ", Manager ID : " + department.manager_id);
            }*//*

            // GetAllJobs : Jobs
            *//*Console.WriteLine("     All Data Jobs     ");
            List<Jobs> jobs = Jobs.GetAllJob();
            foreach (Jobs job in jobs)
            {

                Console.WriteLine("Id : " + job.id + ", Title : " + job.title + ", Min Salary : " + job.min_salary + ",  Max Salary : " + job.max_salary);
            }*//*

            // GetAllHistoy : Histories
            *//*Console.WriteLine("     All Data Histories     ");
            List<History> histories = History.GetAllHistories();
            foreach (History history in histories)
            {

                Console.WriteLine("Employee_ID : " + history.employee_id + ", Start_Date : " + history.start_date + ", End_Date : " + history.end_date + ",  Department ID : " + history.department_id + ", Job_ID : " + history.job_id);
            }*/
/*try
{
    connection.Open();
    Console.WriteLine("Connected");
    connection.Close();
}
catch (Exception ex)
{
    Console.WriteLine("Connection Failed");
}*//*
}
}
}

*/