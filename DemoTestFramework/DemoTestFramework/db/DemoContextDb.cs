using DemoTestFramework.models;
using Microsoft.EntityFrameworkCore;

namespace DemoTestFramework.db
{
    public class DemoContextDb : DbContext
    {
        public DemoContextDb()
        {
            Database.EnsureCreated();
        }

        public DbSet<Planet?> Planets { get; set; }
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Entity1;Username=postgres;Password=admin");
        }
    }
}