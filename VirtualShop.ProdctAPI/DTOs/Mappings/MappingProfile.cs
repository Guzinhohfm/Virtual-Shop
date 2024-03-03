using AutoMapper;
using VirtualShop.ProductAPI.Models;

namespace VirtualShop.ProductAPI.DTOs.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile() 
    { 
        CreateMap<Category, CategoryDTO>().ReverseMap();

        CreateMap<Product, ProductDTO>().ReverseMap();

    }
}
