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

    public async Task<bool> CreateProduct(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        var result = await _productRepository.Add(product);
        return result;
    }

    public PaginationResponse<ProductDto> GetPagedProducts(PaginationRequest request)
    {
        var query = _productRepository.GetAll();
        if (!string.IsNullOrEmpty(request.FilterByName))
        {
            query = query.Where(p => p.Name.ToLower().Contains(request.FilterByName.ToLower()));
        }

        if (request.FilterByCategoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == request.FilterByCategoryId);
        }

        query = request.SortBy?.ToLower() switch
        {
            "price" => request.IsDescending ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price),
            "createddate" => request.IsDescending
                ? query.OrderByDescending(p => p.CreatedDate)
                : query.OrderBy(p => p.CreatedDate),
            "modifieddate" => request.IsDescending
                ? query.OrderByDescending(p => p.ModifiedDate)
                : query.OrderBy(p => p.ModifiedDate),
            "stock" => request.IsDescending ? query.OrderByDescending(p => p.Stock) : query.OrderBy(p => p.Stock),
            _ => request.IsDescending ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name),
        };
        
        var totalItems = query.Count();
        var items = query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();
        var productDtos = _mapper.Map<List<ProductDto>>(items);
        return new PaginationResponse<ProductDto>(totalItems, request.PageNumber, request.PageSize, productDtos);
    }
}