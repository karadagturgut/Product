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
        bool Add(Entity.Product entity);
        bool Update(Entity.Product entity);
        bool Delete(Entity.Product entity);
    }
}
