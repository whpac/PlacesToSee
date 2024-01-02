using System.ComponentModel.DataAnnotations;

using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.WebApp.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        [Url]
        public string PhotoUrl { get; set; } = "";

        public Region() { }

        public Region(IRegion region)
        {
            Id = region.Id;
            Name = region.Name;
            PhotoUrl = region.PhotoUrl;
        }

        public void ApplyTo(IRegion region)
        {
            region.Name = Name;
            region.PhotoUrl = PhotoUrl;
        }
    }
}
