using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Product.Entity.DTO;
using Product.Entity;
namespace Product.Service.Profile
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Entity.Product>().ReverseMap();
            CreateMap<Entity.Product, ProductDTO>();

            CreateMap<ResourceDTO, ResourceText>().ReverseMap();
            CreateMap<Entity.ResourceText, ResourceDTO>();

            CreateMap<ManualLogRequestDTO, ManualLog>().ReverseMap();
            CreateMap<ManualLog, ManualLogRequestDTO>();

        }
    }
}
