using System.Text.Json.Serialization;
using ConsumableMonitor.Models.Interfaces;

namespace ConsumableMonitor.Models;

public class Consumable : IInventoryDefinition
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
    public decimal Cost { get; set; }
    public bool Scrapped { get; set; }
}