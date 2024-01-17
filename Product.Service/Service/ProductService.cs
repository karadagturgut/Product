using Product.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Product.Service.Service
{
    public class ProductService
    {
        private readonly ProductRepository repository;
        public ProductService(ProductRepository repository)
        {
            this.repository = repository;
        }
        public bool Add(Entity.Product entity)
        {
          return repository.Add(entity);
        }

        public bool Delete(Entity.Product entity)
        {
            return repository.Add(entity);
        }

        public IEnumerable<Entity.Product> GetAll()
        {
            return repository.GetAll();
        }

        public Product.Entity.Product GetById(int id)
        {
            return repository.GetById(id);
        }

        public bool Update(Entity.Product entity)
        {
            return repository.Update(entity);
        }
    }
}
