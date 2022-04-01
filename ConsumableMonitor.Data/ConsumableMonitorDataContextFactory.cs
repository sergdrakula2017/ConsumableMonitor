using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsumableMonitor.Data;

public class ConsumableMonitorDataContextFactory : IDesignTimeDbContextFactory<ConsumableMonitorDataContext>
{
    public ConsumableMonitorDataContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ConsumableMonitorDataContext> builder = new();
        string connectionString = args.Any()
            ? string.Join(' ', args)
            : "User ID=postgres;Password=postgres;Host=localhost;Port=5432;";
        Console.WriteLine(@"connectionString = " + connectionString);
        return new(builder
            .UseNpgsql(connectionString)
            .Options);
    }
}