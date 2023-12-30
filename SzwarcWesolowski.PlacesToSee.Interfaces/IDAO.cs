using SzwarcWesolowski.PlacesToSee.Core;

namespace SzwarcWesolowski.PlacesToSee.Interfaces
{
    public interface IDAO
    {
        // TODO: Determine if we need getters by id
        IEnumerable<IPlace> GetPlaces();
        IEnumerable<IRegion> GetRegions();
        IEnumerable<ICountry> GetCountries();

        // TODO: Determine the method parameters
        IPlace CreatePlace();
        IPlace CreatePlace(string name);
        IPlace CreatePlace(string name, PlaceType type, Coordinates location, ICountry country, IRegion region);
        void AddPlace(IPlace item);
        void RemovePlace(IPlace item);
        IRegion CreateRegion();
        IRegion CreateRegion(string name);
        void AddRegion(IRegion item);
        void RemoveRegion(IRegion item);
        ICountry CreateCountry();
        ICountry CreateCountry(string name, string flagUrl);

        void AddCountry(ICountry item);

        void RemoveCountry(ICountry item);
    }
}
