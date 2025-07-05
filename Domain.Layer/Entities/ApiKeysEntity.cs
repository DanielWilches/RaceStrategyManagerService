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
    /// Id,Key,Idcliente, CrateDate, isActivo
    /// </summary>

    [Table("ApiKeys")]
    public class ApiKeysEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", TypeName = "int")]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(10)]
        [Column("Key", TypeName = "nvarchar(255)")]
        public string? Key { get; set; }

        

        [Required]
        [Column("CreateDate", TypeName = "datetime")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [Required]
        [Column("IsActivo", TypeName = "bit")]
        public bool IsActivo { get; set; }

        [Required]
        [Column("Id_Cliente", TypeName = "int")]
        [ForeignKey("ClientsEntity")]
        public int IdCliente { get; set; }       
        public virtual ClientsEntity Client { get; set; }



    }
}
