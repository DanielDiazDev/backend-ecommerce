using EcommerceProject.Service.Contracts;
using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.API.Endpoints;

public static class CartModule
{
    public static void AddCartEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("AddItemToCart", async (AddToCartRequest request, ICartService cartService) =>
        {
            var result = await cartService.AddItemToCart(request);
            return Results.Ok(result);
        });
        app.MapGet("GetCartItems", async (string userId, ICartService cartService) =>
        {
            var result = await cartService.GetCartItems(userId);
            return Results.Ok(result);
        });
        app.MapPut("UpdateCart", async (UpdateCartRequest request, ICartService cartService) =>
        {
            var result = await cartService.UpdateCartItem(request);
            return Results.Ok(result);
        });
        app.MapDelete("RemoveFromCart", async (string userId, Guid productId, ICartService cartService) =>
        {
            var result = await cartService.RemoveFromCart(userId, productId);
            return Results.Ok(result);
        });
        app.MapDelete("ClearCart", async (string userId, ICartService cartService) =>
        {
            var result = await cartService.ClearCart(userId);
            return Results.Ok(result);
        });
    }
}