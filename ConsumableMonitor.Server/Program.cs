
using ConsumableMonitor.Server;

/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();*/

using (Contex db = new Contex())
{
    
    Consumable consumable1 = new Consumable { amountConsumable = 1, Name = "rr22", amountInAPackage = 1, dateTime = new DateTime(2020,1,1), numberOfPackages = 2,packagingCost=222,Status="sklad",sum=222 };
    
    db.Consumables.AddRange(consumable1);
    db.SaveChanges();
   
}
using (Contex db = new Contex())
{
    // получаем объекты из бд и выводим на консоль
    var consumables = db.Consumables.ToList();
    Console.WriteLine("Consumables list:");
    foreach ( Consumable u in consumables)
    {
        Console.WriteLine($"{u.Id}.{u.Name} {u.amountInAPackage} {u.amountConsumable} {u.dateTime} {u.numberOfPackages} {u.packagingCost} {u.Status} {u.sum}");
    }

}


