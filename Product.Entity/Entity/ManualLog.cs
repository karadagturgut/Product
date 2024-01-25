using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Entity
{
    [Table("Log")]
    public class ManualLog
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("MethodName")]
        public string MethodName { get; set; }
        [Column("Request")]
        public string Request { get; set; }
        [Column("Response")]
        public string Response { get; set; }
        [Column("TranDate")]
        public DateTime TranDate { get; set; }
        [Column("IP")]
        public string IP { get; set; }




    }
}
