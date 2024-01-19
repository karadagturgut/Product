using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Entity.DTO
{
	public class ResourceDTO
    {
        public string? ResourceKey { get; set; }
        public string? Value { get; set; }

        public List<string>? ResourceKeyList { get; set; }
    }
}
