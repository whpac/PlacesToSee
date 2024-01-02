using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

using SzwarcWesolowski.PlacesToSee.Core;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.WebApp.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public PlaceType PlaceType { get; set; }

        [Range(-90, 90)]
        public double Latitude { get; set; }
        [Range(-180, 180)]
        public double Longitude { get; set; }

        public int CountryId { get; set; }
        public int RegionId { get; set; }

        public ICountry? Country { get; set; }
        public IRegion? Region { get; set; }

        public Coordinates Location => new(Latitude, Longitude);
        public string LocationString => Location.ToString();

        public IDAO Dao { private get; set; }
        public SelectList CountriesSelectList => new(Dao?.GetCountries() ?? [], "Id", "Name", Country?.Id);
        public SelectList RegionsSelectList => new(Dao?.GetRegions() ?? [], "Id", "Name", Region?.Id);

        public Place() { }

        public Place(IPlace place)
        {
            Id = place.Id;
            Name = place.Name;
            PlaceType = place.PlaceType;
            Latitude = place.Location.Latitude;
            Longitude = place.Location.Longitude;
            Country = place.Country;
            CountryId = Country.Id;
            Region = place.Region;
            RegionId = Region.Id;
        }

        public Place(IPlace place, IDAO dao) : this(place)
        {
            Dao = dao;
        }

        public void ApplyTo(IPlace place)
        {
            place.Name = Name;
            place.PlaceType = PlaceType;
            place.Location = new(Latitude, Longitude);
            place.Country = Country;
            place.Region = Region;
        }
    }
}
