using System.Text.Json.Serialization;
using ConsumableMonitor.Models.Interfaces;

namespace ConsumableMonitor.Models;

public class EquipmentModel : IModel
{
    public int Id { get; set; }
    [JsonIgnore]
    public IList<EquipmentSlotDescriptor>? SlotDescriptors { get; set; }
    [JsonIgnore]
    public IList<Equipment>? Equipments { get; set; }
    public string Producer { get; set; }
    public string Model { get; set; }
    public string ModelCompability { get; set; }//подерживаемые ус-ва 
    public override string ToString()
    {
        return Producer + " " + Model;
        
    }
        

}