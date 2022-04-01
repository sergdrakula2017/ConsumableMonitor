namespace ConsumableMonitor.Models;

public class ConsumableModelFamily
{
    public int Id { get; set; }
    public IList<ConsumableModel> Models { get; set; }
    public IList<EquipmentSlotDescriptor> SlotDescriptors { get; set; }
}