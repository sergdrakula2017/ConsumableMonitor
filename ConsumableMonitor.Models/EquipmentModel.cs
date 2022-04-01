using ConsumableMonitor.Models.Interfaces;

namespace ConsumableMonitor.Models;

public class EquipmentModel : IModel
{
    public int Id { get; set; }

    public IList<EquipmentSlotDescriptor> SlotDescriptors { get; set; }
    public IList<Equipment> Equipments { get; set; }
    public string Producer { get; set; }
    public string Model { get; set; }
}