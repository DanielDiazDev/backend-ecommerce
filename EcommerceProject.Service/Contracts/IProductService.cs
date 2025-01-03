using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.Service.Contracts;

public interface IProductService
{
    Task<bool> CreateProduct(CreateProductDto createProductDto);
    PaginationResponse<ProductDto> GetPagedProducts(PaginationRequest request);
}