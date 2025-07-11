﻿using System;
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
        public DateTime Date { get; set; }
        public int TotalLaps { get; set; }
        public string optimalStrategy { get; set; }     
        public double avgPerformance { get; set; }
        public double avgConsumption { get; set; }
        public int MaxLaps { get; set; }
        public ClientsModels clients { get; set; }
        public PilotsModel pilots { get; set; }
    }
}
