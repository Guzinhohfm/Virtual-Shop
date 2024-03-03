using AutoMapper;
using VirtualShop.ProdctAPI.Models;

namespace VirtualShop.ProdctAPI.DTOs.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile() 
    { 
        CreateMap<Category, CategoryDTO>().ReverseMap();

        CreateMap<Product, ProductDTO>().ReverseMap();

    }
}
