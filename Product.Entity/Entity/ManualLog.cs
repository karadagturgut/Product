using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Entity
{
    [Table("Log")]
    public class ManualLog
    {

        [Column("MethodName")]
        public string MethodName { get; set; }
        [Column("Request")]
        public string Request { get; set; }
        [Column("Response")]
        public string Response { get; set; }
        //[Column("Message")]
        //public string Message { get; set; }

    }
}
