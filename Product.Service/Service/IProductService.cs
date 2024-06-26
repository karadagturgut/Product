﻿using Product.Entity.DTO;
using Product.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.Service
{

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

    public interface IManualLog
    {
        bool Add(ManualLogRequestDTO model);
        IEnumerable<ManualLogRequestDTO> GetByParameter(ManualLogRequestDTO model);
    }
}
