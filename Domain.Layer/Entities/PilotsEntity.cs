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
    /// 
    /// </summary>
    /// 
    [Table("Pilots")]
    public class PilotsEntity
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [Column("Name", TypeName = "varchar(100)")]            
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [Column("Team", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string? Team { get; set; }
        [Required]
        [Column("nationality", TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string? nationality { get; set; }
    }
}
