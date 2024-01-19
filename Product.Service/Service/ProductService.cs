﻿using AutoMapper;
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
        private readonly ILoggingService _loggingService;
        CipherHelper CipherHelper = new CipherHelper();

        public ResourceService(IGenericRepository<ResourceText> repository, IMapper mapper, ILoggingService loggingService)
        {
            _repository = repository;
            _mapper = mapper;
            _loggingService = loggingService;
        }

        public bool Add(ResourceDTO model)
        {
            #region Aynı ResourceKey'e sahip değerler kontrol ediliyor.
            BaseRequestEntity entity = new BaseRequestEntity()
            {
                ColumnName = "ResourceKey",
                Parameters = new List<string> { model.ResourceKey }
            };
            var isExists = _repository.TopOne<ResourceText>(entity);
            if (isExists.Count()>0)
            {
                return false;
            }
            #endregion 

            model.Value = CipherHelper.Encrypt(model.Value);
            var addModel = _mapper.Map<Entity.ResourceText>(model);
            _loggingService.LogInformation("Eklendi.");
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
            return CipherHelper.DecryptByList(returnObject);
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
                Parameters = new List<string> { model.ResourceKey }
           };
            IEnumerable<dynamic> getByKey = _repository.WhereIn<ResourceText>(entity);
            var mapped = _mapper.Map<List<ResourceDTO>>(getByKey);
            return CipherHelper.DecryptByList(mapped);
        }

        public IEnumerable<ResourceDTO> GetByKeyList (ResourceDTO model)
        {
            BaseRequestEntity baseRequestEntity = new BaseRequestEntity()
            {
                ColumnName = "ResourceKey",
                Parameters = model.ResourceKeyList
            };
            IEnumerable<dynamic> getByKeyList = _repository.WhereIn<List<ResourceText>>(baseRequestEntity);
            var mapped = _mapper.Map<List<ResourceDTO>>(getByKeyList);
            return CipherHelper.DecryptByList(mapped);
        }

        public bool Update(ResourceDTO model)
        {
            var updateModel = _mapper.Map<Entity.ResourceText>(model);
            updateModel.Value = CipherHelper.Encrypt(updateModel.Value);
            return _repository.Update(updateModel);
        }
    }
}
