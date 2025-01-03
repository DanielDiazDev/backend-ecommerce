using AutoMapper;
using EcommerceProject.Model;
using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.Service;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterUserDto, UserAccount>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<Product, ProductDto>();
    }
}