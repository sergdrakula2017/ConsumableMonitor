using System.Text.Json.Serialization;

namespace ConsumableMonitor.Models;

public class ConsumableModelFamily
{
    public int Id { get; set; }
    [JsonIgnore]
    public IList<ConsumableModel>? Models { get; set; }
    [JsonIgnore]
    public IList<EquipmentSlotDescriptor>? SlotDescriptors { get; set; }
}