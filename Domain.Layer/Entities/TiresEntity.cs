using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Entities
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Table(("Tires"))]
    public class TiresEntity
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("type", TypeName = "varchar(100)")]
        public string? type { get; set; }

        [Required]
        [Column("Estimated_Laps")]
        public int? EstimatedLaps { get; set; }

        [Required]
        [Column("Consumption_Lap")]

        public double? ConsumptionLap { get; set; }
        [Required]
        [Column("Performance")]
        public int? Performance { get; set; }
    }
}





