using Microsoft.EntityFrameworkCore;

namespace ConsumableMonitor.Server
{
    public class Contex : DbContext
    {
        public DbSet<Consumable> Consumables { get; set; }
        public Contex()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=Consumable12;Username=postgres;Password=admin");
        }
    }
}
