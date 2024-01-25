using Microsoft.EntityFrameworkCore;
using Product.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Context
{
    public class ProductEFContext : DbContext
    {
        public ProductEFContext(DbContextOptions<ProductEFContext> options) : base(options)
        {
        }
        public DbSet<Entity.Product> Products { get; set; }
        public DbSet<Entity.ResourceText> ResourceText { get; set; }
        public DbSet<ManualLog> Logs { get; set; }

    }
}
