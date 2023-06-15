namespace Connection;

public class LINQ
{
    public void Menu()
    {
        var employee = new Employee();
        var job = new Jobs();
        var department = new Department();
        
        // var employees = employee.GetAllEmployee().Where(e => e.first_name.Contains("J"));
        /*var employees = from e in employee.GetAllEmployee()
                        where e.first_name.Contains("J")
                        select e;*/

        /*var employees = employee.GetAllEmployee()
                                .Join(job.GetAllJob(),
                                      e => e.job_id,
                                      j => j.id,
                                      (e, j) => new {
                                          FirstName = e.first_name,
                                          LastName = e.last_name,
                                          Job = j.title
                                      }).LastOrDefault(e => e.FirstName.Contains("J"));*/
        
        var employees = (from e in employee.GetAllEmployee()
                        join j in job.GetAllJob() on e.job_id equals j.id
                        join d in department.GetAllDepartment() on e.department_id equals d.id
                        select new {
                            FirstName = e.first_name,
                            LastName = e.last_name,
                            Job = j.title,
                            Department = d.name
                        });
        

        // Console.WriteLine($"{employees.FirstName} {employees.LastName} {employees.Job} {employees.Department}");

        Console.WriteLine(employees.Count() == 0);
        
        /*foreach (var emp in employees) {
            Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Job}");
        }*/
        
        var huruf = "J";
        var angka = 1;
    }
}
