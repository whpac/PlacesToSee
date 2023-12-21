using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.DAO.MemoryBased
{
    internal record Region : IRegion
    {
        public string Name { get; set; }

        public string PhotoUrl { get; set; }
    }
}
