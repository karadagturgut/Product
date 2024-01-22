using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Entity.DTO
{
    public class BaseDTO
    {
       
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
