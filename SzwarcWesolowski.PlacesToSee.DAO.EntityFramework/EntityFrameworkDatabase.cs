using Microsoft.EntityFrameworkCore;

using SzwarcWesolowski.PlacesToSee.Core;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.DAO.EntityFramework
{
    public class EntityFrameworkDatabase : IDAO
    {
        private static readonly DataContext dataContext = new();

        public void AddCountry(ICountry item)
        {
            dataContext.Add((Country)item);
            dataContext.SaveChanges();
        }

        public void AddPlace(IPlace item)
        {
            dataContext.Add((Place)item);
            dataContext.SaveChanges();
        }

        public void AddRegion(IRegion item)
        {
            dataContext.Add((Region)item);
            dataContext.SaveChanges();
        }

        public ICountry CreateCountry() => new Country();

        public ICountry CreateCountry(string name, string flagUrl) => new Country(name, flagUrl);

        public IPlace CreatePlace() => new Place();

        public IPlace CreatePlace(string name) => new Place
        {
            Name = name
        };

        public IPlace CreatePlace(string name, PlaceType type, Coordinates location, ICountry country, IRegion region)
            => new Place
        {
            Name = name,
            PlaceType = type,
            Location = location,
            Country = country,
            Region = region
        };

        public IRegion CreateRegion() => new Region();

        public IRegion CreateRegion(string name) => new Region(name);

        public IRegion CreateRegion(string name, string photoUrl) => new Region(name, photoUrl);

        public IEnumerable<ICountry> GetCountries() => dataContext.Countries;
        public IEnumerable<IRegion> GetRegions() => dataContext.Regions;
        public IEnumerable<IPlace> GetPlaces() => dataContext.Places
            .Include(place => place._country).Include(place => place._region);

        public void RemoveCountry(ICountry item)
        {
            dataContext.Countries.Remove((Country)item);
            dataContext.SaveChanges();
        }

        public void RemovePlace(IPlace item)
        {
            dataContext.Places.Remove((Place)item);
            dataContext.SaveChanges();
        }

        public void RemoveRegion(IRegion item)
        {
            dataContext.Regions.Remove((Region)item);
            dataContext.SaveChanges();
        }

        public void UpdateCountry(ICountry item)
        {
            dataContext.Update((Country)item);
            dataContext.SaveChanges();
        }

        public void UpdatePlace(IPlace item)
        {
            dataContext.Update((Place)item);
            dataContext.SaveChanges();
        }

        public void UpdateRegion(IRegion item)
        {
            dataContext.Update((Region)item);
            dataContext.SaveChanges();
        }
    }
}
