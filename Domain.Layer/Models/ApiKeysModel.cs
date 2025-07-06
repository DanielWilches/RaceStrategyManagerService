using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer.Models
{
    public class ApiKeysModel
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public int IdCliente { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActivo { get; set; }
    }
}
