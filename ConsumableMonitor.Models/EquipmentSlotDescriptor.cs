using System.Text.Json.Serialization;

namespace ConsumableMonitor.Models;

public class EquipmentSlotDescriptor
{
    public int ModelId { get; set; }
    [JsonIgnore]
    public EquipmentModel? EquipmentModel { get; set; }
    public int SlotNumber { get; set; }
    public int ConsumableModelFamilyId { get; set; }
    [JsonIgnore]
    public ConsumableModelFamily? ConsumableModelFamily { get; set; }
}