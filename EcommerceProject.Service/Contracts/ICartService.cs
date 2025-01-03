using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.Service.Contracts;

public interface ICartService
{
    Task<bool> AddItemToCart(AddToCartRequest request);
    Task<List<CartItemDto>> GetCartItems(string userId);
    Task<bool> UpdateCartItem(UpdateCartRequest request);
    Task<bool> RemoveFromCart(string userId, Guid productId);
    Task<bool> ClearCart(string userId);
}