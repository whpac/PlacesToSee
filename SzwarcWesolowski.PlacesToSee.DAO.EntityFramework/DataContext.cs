using Microsoft.EntityFrameworkCore;

namespace SzwarcWesolowski.PlacesToSee.DAO.EntityFramework
{
    internal class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite("Data Source=:memory:;Version=3;New=True;");
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
    }
}
