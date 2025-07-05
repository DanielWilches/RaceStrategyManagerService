using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Models
{
    //Id,Nombre,Email,Descripcion,isActivo

    /// <summary>
    /// 
    /// </summary>
    /// 
    public class ClientsModels
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public bool isActivo { get; set; } = false;
    }
}
