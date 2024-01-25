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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public ResourceDTO Add(ResourceDTO model)
        {
            #region Aynı ResourceKey'e sahip değerler kontrol ediliyor.

            BaseRequestEntity entity = new BaseRequestEntity()
            {
                ColumnName = "ResourceKey",
                Parameters = new List<string> { model.ResourceKey }
            };
            var isExists = _repository.TopOne<ResourceText>(entity);
            if (isExists.Count() > 0)
            {
                _loggingService.LogError($"{model.ResourceKey} hali hazırda bulunuyor.", new Exception());
                return new ResourceDTO() { Success = false, Message = GetByResourceKey("ExistingKey") };
            }
            #endregion

            #region bazı alanlar setleniyor ve servisten dönüş kontrol ediliyor.

            model.Value = CipherHelper.Encrypt(model.Value);
            var addModel = _mapper.Map<Entity.ResourceText>(model);
            model.Success = _repository.Add(addModel);

            if (!model.Success)
            {
                _loggingService.LogError("Ekleme servisi success false döndü.", new Exception());
                return new ResourceDTO() { Success = false, Message = GetByResourceKey("ExistingKey"), };
            }

            #endregion

            return new ResourceDTO() { Success = model.Success, Message = GetByResourceKey("Added") };
        }
        public ResourceDTO Delete(ResourceDTO model)
        {
            var removeModel = _mapper?.Map<Entity.ResourceText>(model);
            model.Success = _repository.Delete(removeModel);

            if (!model.Success)
            {
                _loggingService.LogError("Silme servisi success false döndü.", new Exception());
                return new ResourceDTO() { Success = false, Message = GetByResourceKey("ExistingKey"), };
            }
            return new ResourceDTO() { Success = model.Success, Message = GetByResourceKey("ExistingKey"), };
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

        public IEnumerable<ResourceDTO> GetByKeyList(ResourceDTO model)
        {
            try
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
            catch (Exception ex)
            {
                _loggingService.LogError(ex.Message,ex);
                throw;
            }
           
        }

        public bool Update(ResourceDTO model)
        {
            var updateModel = _mapper.Map<Entity.ResourceText>(model);
            updateModel.Value = CipherHelper.Encrypt(updateModel.Value);
            return _repository.Update(updateModel);
        }

        private string? GetByResourceKey(string ResourceKey)
        {
            return GetByKey(new ResourceDTO { ResourceKey = ResourceKey }).First().Value;
        }
    }

    #region  ManualLogService: Tüm adımların başarılı/başarısız olmasından bağımsız olarak loglanması.
    public class ManualLogService : IManualLog
    {
        private readonly IGenericRepository<ManualLog> _repository;
        private readonly IMapper _mapper;

        public ManualLogService(IMapper mapper, IGenericRepository<ManualLog> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public bool Add(ManualLogRequestDTO model)
        {
            try
            {
                var mapped = _mapper.Map<ManualLog>(model);
                var success = _repository.Add(mapped);
                if (!success)
                {
                    throw new Exception("DB'ye manuel log atılırken hata oluştu.");
                }
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ManualLogRequestDTO> GetByParameter(ManualLogRequestDTO model)
        {
            var returnObject = new List<ManualLogRequestDTO>();
            BaseRequestEntity entity = new BaseRequestEntity()
            {
                ColumnName = model.ColumnName,
                Parameters = new List<string> { model.Parameter }
            };
            return returnObject;
        }
    }

}
#endregion