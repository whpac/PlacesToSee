using SzwarcWesolowski.PlacesToSee.Core;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.DAO.MemoryBased
{
    public partial class MemoryDatabase : IDAO
    {
        private readonly List<Place> _places = [];
        private readonly List<Region> _regions = [];
        private readonly List<Country> _countries = [];

        public MemoryDatabase()
        {
            InitializeData();
        }

        public IEnumerable<IPlace> GetPlaces() => _places;
        public IEnumerable<IRegion> GetRegions() => _regions;
        public IEnumerable<ICountry> GetCountries() => _countries;

        public IPlace CreatePlace() => new Place();
        public IPlace CreatePlace(string name) {
            var item = new Place {Name = name};
            _places.Add (item);
            return item;
        }

        public IPlace CreatePlace(string name, PlaceType type, Coordinates location, ICountry country, IRegion region) {
            var item = new Place
            {
            Name = name,
            Country = country,
            Location = location,
            PlaceType = type,
            Region = region
            };
            _places.Add (item);
            return item;
        }

        public void AddPlace(IPlace item) {
            _places.Add ((Place) item);
        }

        public void RemovePlace(IPlace item) {
            _places.Remove ((Place) item);
        }

        public IRegion CreateRegion() => new Region();
        public IRegion CreateRegion(string name) {
            var item = new Region
            {
                Name = name, 
                PhotoUrl = ""
            };
            _regions.Add (item);
            return item;
        }
        public IRegion CreateRegion(string name, string photoUrl)
        {
            var item = new Region
            {
                Name = name,
                PhotoUrl = photoUrl
            };
            _regions.Add(item);
            return item;
        }

        public void AddRegion(IRegion item) {
            _regions.Add ((Region) item);
        }

        public void RemoveRegion(IRegion item) {
            _regions.Remove ((Region) item);
        }

        public ICountry CreateCountry() => new Country ();
        public ICountry CreateCountry(string name, string flagUrl) {
            var item = new Country {
                Name = name,
                FlagUrl = flagUrl
            };
            _countries.Add (item);
            return item;
        }

        public void AddCountry(ICountry item) {
            _countries.Add ((Country) item);
        }

        public void RemoveCountry(ICountry item) {
            _countries.Remove ((Country) item);
        }

        public void UpdateCountry(ICountry item) { }
        public void UpdatePlace(IPlace item) { }
        public void UpdateRegion(IRegion item) { }
    }
}
