using Domain.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.DTOs
{
    public class CombinationsDTO
    {
        public int TotalLabs { get; set; }
        public List<int>? AvgPerformance { get; set; }
        public List<double>? AvgConsumption { get; set; }
        public List<TiresModel> Strateys { get; set; } = new();
    }
}
