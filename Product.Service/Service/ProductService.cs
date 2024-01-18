using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Product.Core;
using Product.Core.GeneralHelper;
using Product.Entity;
using Product.Entity.DTO;
using Product.Entity.Entity;
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

    public class ResourceService : IResourceTextService
    {
        private readonly IGenericRepository<Entity.ResourceText> _repository;
        private readonly IMapper _mapper;
        CipherHelper CipherHelper = new CipherHelper();

        public ResourceService(IGenericRepository<ResourceText> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool Add(ResourceDTO model)
        {
            model.Value = CipherHelper.Encrypt(model.Value);
            var addModel = _mapper.Map<Entity.ResourceText>(model);
            return _repository.Add(addModel);
        }

        public bool Delete(ResourceDTO model)
        {
            var removeModel = _mapper?.Map<Entity.ResourceText>(model);
            return _repository.Delete(removeModel);
        }

        public IEnumerable<ResourceDTO> GetAll()
        {
            var getAllModel = _repository.GetAll();
            var returnObject = _mapper.Map<List<ResourceDTO>>(getAllModel);
            return returnObject;
        }

        public ResourceDTO GetById(int id)
        {

            var entity = _repository.GetById(id);
            var returnObject = _mapper.Map<ResourceDTO>(entity);
            returnObject.Value = CipherHelper.Decrypt(returnObject.Value);
            return returnObject;
        }

        public IEnumerable<ResourceDTO> GetByKey(ResourceDTO model)
        {
            BaseRequestEntity entity = new BaseRequestEntity()
            {
                ColumnName = "ResourceKey",
                Parameters = new[] { model.Value }
           };
            var getByKey = _repository.ByColumnNameAndParameters<ResourceText>(entity);
            var mapped = _mapper.Map<List<ResourceDTO>>(getByKey);
            return mapped;
        }

        public bool Update(ResourceDTO model)
        {
            var updateModel = _mapper.Map<Entity.ResourceText>(model);
            return _repository.Update(updateModel);
        }
    }
}
