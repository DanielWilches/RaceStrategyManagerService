using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class PilotsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Team { get; set; }
        public string? nationality { get; set; }
    }
}
