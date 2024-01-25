using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Entity.DTO
{
    public class ManualLogRequestDTO
    {
        public string MethodName { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string? Message { get; set; }

        public string IP { get; set; }

        public DateTime TranDate { get; set; }
        public string ColumnName { get; set; }
        public string Parameter { get; set; }
    }
}
