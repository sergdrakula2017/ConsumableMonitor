using System.Text.Json.Serialization;
using ConsumableMonitor.Models.Interfaces;

namespace ConsumableMonitor.Models;

public class ConsumableModel : IModel
{
    public int Id { get; set; }
    [JsonIgnore]
    public IList<EquipmentSlotDescriptor>? SupportedSlotDescriptors { get; set; }
    [JsonIgnore]
    public IList<Consumable>? Consumables { get; set; }

    public int FamilyId { get; set; }
    [JsonIgnore]
    public ConsumableModelFamily? Family { get; set; }
    public string Producer { get; set; }
    public string Model { get; set; }
    public override string ToString()
    {
        return Producer+" "+Model;

    }
}