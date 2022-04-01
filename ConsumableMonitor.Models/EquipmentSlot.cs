namespace ConsumableMonitor.Models;

public class EquipmentSlot
{
    public int EquipmentId { get; set; }
    public Equipment Equipment { get; set; }
    public int SlotNumber { get; set; }
    public int InstalledId { get; set; }
    public Consumable? Installed { get; set; }
}