namespace ConsumableMonitor.Models.Interfaces;

public interface IInventoryDefinition
{
    int ModelId { get; set; }
    string SerialNumber { get; set; }
    string Alias { get; set; }
    string Description { get; set; }
    bool Scrapped { get; set; }
    decimal Cost { get; set; }
   

}