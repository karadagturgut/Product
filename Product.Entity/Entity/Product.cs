using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Entity
{
        [Table("tbl_Product")]
        public class Product
        {
            [Key]
            [Column("Id")]
            public int Id { get; set; }

            [Column("Product_Name")]
            public string Name { get; set; }

            [Column("Product_Description")]
            public string Description { get; set; }

            [Column("Price")]
            public decimal Price { get; set; }
        }
}
