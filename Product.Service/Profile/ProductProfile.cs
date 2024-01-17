using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Product.Entity.DTO;
namespace Product.Service.Profile
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile() 
        {
            CreateMap<ProductDTO,Entity.Product>().ReverseMap();
            CreateMap<Entity.Product, ProductDTO>();
        }
    }
}
