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
        IRegion CreateRegion();
        ICountry CreateCountry();
        ICountry CreateCountry(string name, string flagUrl);

        void AddCountry(ICountry item);

        void RemoveCountry(ICountry item);
    }
}
