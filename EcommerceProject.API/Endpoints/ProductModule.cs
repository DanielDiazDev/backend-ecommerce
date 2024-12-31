using EcommerceProject.Service.Contracts;
using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.API.Endpoints;

public static class ProductModule
{
    public static void AddProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("CreateProduct", async (CreateProductDTO createProductDTO, IProductService productService) =>
        {
            var result = await productService.CreateProduct(createProductDTO);
            return Results.Ok(result);
        });
        
    }
}