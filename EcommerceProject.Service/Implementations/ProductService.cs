using AutoMapper;
using EcommerceProject.Data.Repositories.Contracts;
using EcommerceProject.Model;
using EcommerceProject.Service.Contracts;
using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.Service.Implementations;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;
    private IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<bool> CreateProduct(CreateProductDTO createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        var result = await _productRepository.Add(product);
        return result;
    }
}