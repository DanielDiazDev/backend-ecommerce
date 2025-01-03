using EcommerceProject.Service.Contracts;
using EcommerceProject.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.API.Endpoints;

public static class ProductModule
{
    public static void AddProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("CreateProduct", async (CreateProductDto createProductDTO, IProductService productService) =>
        {
            var result = await productService.CreateProduct(createProductDTO);
            return Results.Ok(result);
        });
        app.MapPost("GetPagedProducts", (PaginationRequest request, IProductService productService) => //Analizar si hacerlo get
        {
            var result = productService.GetPagedProducts(request);
            return Results.Ok(result);
        });
       
    }
}