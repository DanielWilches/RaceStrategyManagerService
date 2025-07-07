using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.DTOs
{
    public class CombinationsDTO
    {
        public List<string> Strateys { get; set; }
        public List<string> IdStrateys { get; set; }
        public int? totalLabs { get; set; }
        public double? avgPerformance { get; set; }
        public double? avgConsumption { get; set; }
    }
}
