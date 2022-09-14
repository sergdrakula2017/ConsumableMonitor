using System.Text.Json.Serialization;
using ConsumableMonitor.Models.Interfaces;

namespace ConsumableMonitor.Models;

public record class Consumable : IInventoryDefinition
{
    public int Id { get; set; }
    [JsonIgnore]
    public ConsumableModel? Model { get; set; }
    public int? InstalledInEquipmentId { get; set; }
    public int? InstalledInNumber { get; set; }
    [JsonIgnore]
    public EquipmentSlot? InstalledIn { get; set; }
    public int ModelId { get; set; }
    public string SerialNumber { get; set; }
    public string Alias { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }//delete
    public bool Scrapped { get; set; }//???
    public string ?Color { get; set; }//цвет расходного материала 
    public string ModelCompability { get; set; }//подерживаемые ус-ва 
    public int count { get; set; }//количество расходников на складе 
    
}