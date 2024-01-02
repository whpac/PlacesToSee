using SzwarcWesolowski.PlacesToSee.Core;

namespace SzwarcWesolowski.PlacesToSee.Interfaces
{
    public interface IPlace
    {
        int Id { get; set; }
        string Name { get; set; }
        PlaceType PlaceType { get; set; }
        Coordinates Location { get; set; }

        ICountry Country { get; set; }
        IRegion Region { get; set; }
    }
}
