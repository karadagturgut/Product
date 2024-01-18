using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Entity.Entity
{
    public class BaseRequestEntity
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string[] Parameters { get; set; }

    }
}
