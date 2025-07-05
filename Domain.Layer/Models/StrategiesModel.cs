using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Models
{
    public class StrategiesModel
    {
        public int Id { get; set; }
        public int PilotId { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public int TotalLaps { get; set; }
    }
}
