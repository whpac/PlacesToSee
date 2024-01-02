using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.DAO.EntityFramework
{
    internal class Region : IRegion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }

        public List<Place> Places { get; set; } = [];

        public Region() { }

        public Region(string name)
        {
            Name = name;
        }

        public Region(string name, string photoUrl)
        {
            Name = name;
            PhotoUrl = photoUrl;
        }
    }
}
