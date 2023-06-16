using Connection.Models;

namespace Connection.Views;

public class RegionView
{
    public void GetById(Region region)
    {
        Console.WriteLine("Id : " + region.Id + ", Name : " + region.Name);
    }

    public void GetAll(List<Region> regions)
    {
        foreach (var region in regions) {
            GetById(region);
        }
    }
    
    public void NotFound()
    {
        Console.WriteLine("Data not found");
    }
}
