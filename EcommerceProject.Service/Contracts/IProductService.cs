using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.Service.Contracts;

public interface IProductService
{
    Task<bool> CreateProduct(CreateProductDTO createProductDto);
}