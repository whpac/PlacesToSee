using SzwarcWesolowski.PlacesToSee.BLC;

namespace SzwarcWesolowski.PlacesToSee.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var daoPath = @"SzwarcWesolowski.PlacesToSee.DAO.MemoryBased.dll";
            ExternalDAOManager.Initialize(daoPath);
            var dao = ExternalDAOManager.GetDAOInstance();

            Console.WriteLine("== Countries ==");
            foreach (var country in dao.GetCountries())
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("\n== Regions ==");
            foreach (var region in dao.GetRegions())
            {
                Console.WriteLine(region);
            }

            Console.WriteLine("\n== Places ==");
            foreach (var place in  dao.GetPlaces())
            {
                Console.WriteLine(place);
            }
        }
    }
}
