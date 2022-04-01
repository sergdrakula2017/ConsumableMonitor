namespace ConsumableMonitor.Models;

public class EquipmentSlotDescriptor
{
    public int ModelId { get; set; }
    public EquipmentModel EquipmentModel { get; set; }
    public int SlotNumber { get; set; }
    public int ConsumableModelFamilyId { get; set; }
    public ConsumableModelFamily ConsumableModelFamily { get; set; }
}