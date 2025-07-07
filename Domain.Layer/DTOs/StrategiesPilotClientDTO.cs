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
        public int Id_Strategy { get; set; }
        public DateTime Date { get; set; }
        public int Total_Laps { get; set; }
        public int Max_Laps { get; set; }
        public string Optimal_Strategy { get; set; }
        public double Avg_Performance { get; set; }
        public double avg_Consumption { get; set; }
        public int Pilot_Id { get; set; }
        public int Client_Id { get; set; }
        public int Id_Pilot { get; set; }
        public string Name_Pilot { get; set; }
        public string Team { get; set; }
        public string nationality { get; set; }
        public int Id_Client { get; set; }
        public string Name_Client { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool isActivo { get; set; }
    }
}
