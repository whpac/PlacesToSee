using SzwarcWesolowski.PlacesToSee.Core;

namespace SzwarcWesolowski.PlacesToSee.DAO.MemoryBased
{
    public partial class MemoryDatabase
    {
        private void InitializeData()
        {
            var pl = new Country
            {
                Name = "Polska",
                FlagUrl = ""
            };
            var cs = new Country
            {
                Name = "Czechy",
                FlagUrl = ""
            };
            countries.AddRange([pl, cs]);

            var bogatynia = new Region
            {
                Name = "Okolice Bogatyni",
                PhotoUrl = ""
            };
            regions.AddRange([bogatynia]);

            places.Add(new Place
            {
                Name = "Výhledy",
                Country = cs,
                PlaceType = PlaceType.OpenAir,
                Region = bogatynia,
                Location = new(50.861438, 14.964688)
            });
            places.Add(new Place
            {
                Name = "U Alchemika",
                Country = pl,
                PlaceType = PlaceType.Building,
                Region = bogatynia,
                Location = new(50.875687, 14.960062)
            });
        }
    }
}
