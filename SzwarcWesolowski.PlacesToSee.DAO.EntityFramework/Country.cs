using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.DAO.EntityFramework
{
    internal class Country : ICountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FlagUrl { get; set; }

        public List<Place> Places { get; set; } = [];

        public Country() { }

        public Country(string name, string flagUrl)
        {
            Name = name;
            FlagUrl = flagUrl;
        }
    }
}
