using AutoMapper;
using OnlineShopping.Data.Entities;
using OnlineShopping.WebApi.Models;

namespace OnlineShopping.WebApi
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
        }


    }
}
