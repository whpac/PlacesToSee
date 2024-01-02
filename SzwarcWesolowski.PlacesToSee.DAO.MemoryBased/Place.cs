using SzwarcWesolowski.PlacesToSee.Core;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.DAO.MemoryBased
{
    internal record Place : IPlace
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PlaceType PlaceType { get; set; }

        public Coordinates Location { get; set; }

        public ICountry Country { get; set; }

        public IRegion Region { get; set; }
    }
}
