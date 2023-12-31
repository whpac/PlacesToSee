using SzwarcWesolowski.PlacesToSee.Core;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.DAO.MemoryBased
{
    public partial class MemoryDatabase
    {
        private void InitializeData()
        {
            var pl = new Country
            {
                Name = "Polska",
                FlagUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e9/Flag_of_Poland_%28normative%29.svg/250px-Flag_of_Poland_%28normative%29.svg.png"
            };
            var cs = new Country
            {
                Name = "Czechy",
                FlagUrl = ""
            };
            _countries.AddRange([pl, cs]);

            var bogatynia = new Region
            {
                Name = "Okolice Bogatyni",
                PhotoUrl = ""
            };
            _regions.AddRange([bogatynia]);

            _places.Add(new Place
            {
                Name = "Výhledy",
                Country = cs,
                PlaceType = PlaceType.OpenAir,
                Region = bogatynia,
                Location = new(50.861438, 14.964688)
            });
            _places.Add(new Place
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
