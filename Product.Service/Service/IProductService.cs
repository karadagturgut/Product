using Product.Entity.DTO;
using Product.Entity.Entity;
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
    public interface IResourceTextService
    {
        ResourceDTO GetById(int id);
        IEnumerable<ResourceDTO> GetAll();
        ResourceDTO Add(ResourceDTO model);
        bool Update(ResourceDTO entity);
        ResourceDTO Delete(ResourceDTO model);
        IEnumerable<ResourceDTO> GetByKey(ResourceDTO entity);
        IEnumerable<ResourceDTO> GetByKeyList(ResourceDTO model);
    }
}
