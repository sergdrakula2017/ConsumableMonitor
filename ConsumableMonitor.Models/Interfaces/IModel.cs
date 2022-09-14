namespace ConsumableMonitor.Models.Interfaces;

public interface IModel
{
    string Producer { get; set; }
    string Model { get; set; }
    public string ModelCompability { get; set; }
}