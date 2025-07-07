using Domain.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.DTOs
{
    public class StrategiesPilotClientDTO
    {
        public int Id { get; set; }
        public int PilotId { get; set; }
        public PilotsModel pilot { get; set; }
        public int ClientId { get; set; }
        public ClientsModels client { get; set; }
        public DateTime Date { get; set; }
        public int TotalLaps { get; set; }
        public string optimalStrategy { get; set; }
        public double avgPerformance { get; set; }
        public double avgConsumption { get; set; }
        public int MaxLaps { get; set; }


    }
}
