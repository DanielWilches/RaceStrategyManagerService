using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Models
{
    public class TiresModel
    {
        public int Id { get; set; }
        public string? type { get; set; }
        public int? EstimatedLaps { get; set; }
        public double? ConsumptionLap { get; set; }
        public int? Performance { get; set; }
    }
}
