using AutoMapper;
using Product.Core;
using Product.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Product.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Entity.Product> _repository;
        private readonly IMapper mapper;
        public ProductService(IGenericRepository<Entity.Product> repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }
        public bool Add(ProductDTO entity)
        {
            var mapped = mapper.Map<Entity.Product>(entity);
            return _repository.Add(mapped);
        }

        public bool Delete(ProductDTO entity)
        {
            var mapped = mapper.Map<Entity.Product>(entity);
            return _repository.Add(mapped);
        }

        public IEnumerable<Entity.Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Entity.Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Update(ProductDTO entity)
        {
            var mapped = mapper.Map<Entity.Product>(entity);
            return _repository.Update(mapped);
        }
    }
}
