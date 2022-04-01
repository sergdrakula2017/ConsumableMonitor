using System.Text.Json.Serialization;

namespace ConsumableMonitor.Models;

public class EquipmentSlot
{
    public int EquipmentId { get; set; }
    [JsonIgnore]
    public Equipment? Equipment { get; set; }
    public int SlotNumber { get; set; }
    [JsonIgnore]
    public Consumable? Installed { get; set; }
}