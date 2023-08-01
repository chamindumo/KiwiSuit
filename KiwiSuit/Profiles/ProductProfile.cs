using AutoMapper;
using KiwiSuit.DTO;
using KiwiSuit.Models;

namespace KiwiSuit.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }

    }
}
