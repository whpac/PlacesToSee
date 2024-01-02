using System.ComponentModel.DataAnnotations.Schema;

using SzwarcWesolowski.PlacesToSee.Core;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.DAO.EntityFramework
{
    internal class Place : IPlace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlaceType PlaceType { get; set; }
        [NotMapped]
        public Coordinates Location {
            get => new (Latitude, Longitude);
            set
            {
                Latitude = value.Latitude;
                Longitude = value.Longitude;
            }
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Country _country { get; set; }
        public Region _region { get; set; }

        [NotMapped]
        public ICountry Country
        {
            get => _country;
            set => _country = (Country)value;
        }
        [NotMapped]
        public IRegion Region
        {
            get => _region;
            set => _region = (Region)value;
        }
    }
}
