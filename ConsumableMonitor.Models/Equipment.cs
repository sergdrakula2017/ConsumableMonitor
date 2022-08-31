using System.Text.Json.Serialization;
using ConsumableMonitor.Models.Interfaces;

namespace ConsumableMonitor.Models;

public class Equipment : IInventoryDefinition
{
    public int Id { get; set; }
    [JsonIgnore]
    public EquipmentModel? Model { get; set; }
    /*
    [JsonIgnore] //
    public EquipmentModel? Producer { get; set; }//
    */
    [JsonIgnore]
    public IList<EquipmentSlot>? Slots { get; set; }
    public int ModelId { get; set; }

    public string SerialNumber { get; set; }
    public string Alias { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
    public bool Scrapped { get; set; }
}