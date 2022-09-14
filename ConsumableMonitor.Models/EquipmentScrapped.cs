using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using ConsumableMonitor.Models.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace ConsumableMonitor.Models;

public record class EquipmentScrapped
{
    public string Model { get; set; }
    public string Producer { get; set; }
    public string Alias { get; set; }
    public string SerialNubmer { get; set; }
    public int CountSlots   { get; set; }
    public string ModelCompability { get; set; }
    public string Reason { get; set; }
    public DateTime DateSrapped { get; set; }
}
