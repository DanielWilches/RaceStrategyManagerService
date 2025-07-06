using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Entities
{
    ///Id,Nombre,Email,Descripcion,isActivo
    /// <summary>
    /// 
    /// </summary>
    [Table("Clients")]
    public class ClientsEntity
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
        [Column("Email", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string? Email { get; set; }
        
        [Required]
        [Column("Description", TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        [Column("isActivo")]
        public bool isActivo { get; set; }
    }
}
