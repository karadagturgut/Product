using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Entity
{
    [Table("ResourceText")]
    public class ResourceText
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("ResourceKey")]
        public string ResourceKey { get; set; }
        [Column("Value")]
        public string Value { get; set; }
    }
}
