using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.DAO.MemoryBased
{
    internal record Country : ICountry
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FlagUrl { get; set;  }
    }
}
