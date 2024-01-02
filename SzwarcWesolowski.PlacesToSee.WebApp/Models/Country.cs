using System.ComponentModel.DataAnnotations;

using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.WebApp.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        [Url]
        public string FlagUrl { get; set; } = "";

        public Country() { }

        public Country(ICountry country)
        {
            Id = country.Id;
            Name = country.Name;
            FlagUrl = country.FlagUrl;
        }

        public void ApplyTo(ICountry country)
        {
            country.Name = Name;
            country.FlagUrl = FlagUrl;
        }
    }
}
