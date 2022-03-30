using ConsumableMonitor.Models.Interfaces;

namespace ConsumableMonitor.Models;

public class ConsumableModel : IModel
{
    public int Id { get; set; }
    public IList<EquipmentSlotDescriptor> SupportedSlotDescriptors { get; set; }
    public IList<Consumable> Consumables { get; set; }

    public int FamilyId { get; set; }
    public ConsumableModelFamily Family { get; set; }
    public string Producer { get; set; }
    public string Model { get; set; }
}