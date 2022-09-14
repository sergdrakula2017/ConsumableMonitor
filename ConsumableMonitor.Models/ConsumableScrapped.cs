using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumableMonitor.Models;

public record class ConsumableScrapped
{
    public string Model { get; set; }
    public string Alias { get; set; }
    public string Color { get; set; }
    public DateTime DateScrapped { get; set; }

}
