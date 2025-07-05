using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Entities
{
    /// <summary>
    /// Id, PilotoId, Client id, Fecha, TotalVueltas
    /// </summary>
    /// 
    [Table("Strategies")]
    public class StrategiesEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Pilot_ Id")]
        [Required]
        [ForeignKey("Pilots")]
        public int PilotId { get; set; }

        [Column("Client_Id")]
        [Required]
        [ForeignKey("Clients")]
        public int ClientId { get; set; }

        [Column("Date", TypeName = "datetime2")]
        [Required]
        public DateTime Date { get; set; }  

        [Column("Total_Laps")]
        [Required]
        public int TotalLaps { get; set; }

    }
}
