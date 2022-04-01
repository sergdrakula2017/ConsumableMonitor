using ConsumableMonitor.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsumableMonitor.Server;

public class Startup
{
    public Startup(IConfiguration configuration) => Configuration = configuration;
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ConsumableMonitorDataContext>(x => x.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

        services.AddControllers();
        services.AddHealthChecks().AddDbContextCheck<ConsumableMonitorDataContext>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseHealthChecks("/api/health");
        app.UseEndpoints(builder => { builder.MapControllers(); });
    }
}