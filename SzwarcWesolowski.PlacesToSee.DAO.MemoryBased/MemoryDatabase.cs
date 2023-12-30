using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.DAO.MemoryBased
{
    public partial class MemoryDatabase : IDAO
    {
        private readonly List<Place> places = [];
        private readonly List<Region> regions = [];
        private readonly List<Country> countries = [];

        public MemoryDatabase()
        {
            InitializeData();
        }

        public IEnumerable<IPlace> GetPlaces() => places;
        public IEnumerable<IRegion> GetRegions() => regions;
        public IEnumerable<ICountry> GetCountries() => countries;

        public IPlace CreatePlace() => new Place();
        public IRegion CreateRegion() => new Region();
        public ICountry CreateCountry(string name, string flagUrl) {
            var country = new Country{
                Name = name,
                FlagUrl = flagUrl
            };
            countries.Add (country);
            return country;
        }

        public void RemoveCountry(ICountry item) {
            countries.Remove ((Country) item);
            Console.WriteLine ("deleted object " + item);
        }
    }
}
