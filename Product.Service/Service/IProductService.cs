using Product.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.Service
{
    public interface IProductService  
    {

        Entity.Product GetById(int id);
        IEnumerable<Entity.Product> GetAll();
        bool Add(ProductDTO entity);
        bool Update(ProductDTO entity);
        bool Delete(ProductDTO entity);
    }
}
