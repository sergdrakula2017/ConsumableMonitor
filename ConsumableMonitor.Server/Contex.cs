using Microsoft.EntityFrameworkCore;

namespace ConsumableMonitor.Server
{
    public class Contex : DbContext
    {
        public DbSet<Consumable> Consumables { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Consumable12;Username=postgres;Password=admin");
        }
    }
}
