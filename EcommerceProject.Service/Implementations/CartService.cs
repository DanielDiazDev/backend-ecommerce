using EcommerceProject.Data.Repositories.Contracts;
using EcommerceProject.Service.Contracts;
using EcommerceProject.Shared.Dtos;
using Newtonsoft.Json;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IRedisRepository _redisRepository;

    public CartService(
        ICartRepository cartRepository, 
        IProductRepository productRepository,
        IRedisRepository redisRepository)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _redisRepository = redisRepository;
    }

    public async Task<bool> AddItemToCart(AddToCartRequest request)
    {
        var cartKey = $"cart:{request.UserId}";
        var cartJson = await _redisRepository.Get(cartKey);
        var cartItems = string.IsNullOrEmpty(cartJson)
            ? new List<CartItemDto>()
            : JsonConvert.DeserializeObject<List<CartItemDto>>(cartJson);

        var existingItem = cartItems.FirstOrDefault(i => i.ProductId == request.CartItem.ProductId);
        if (existingItem == null)
        {
            cartItems.Add(request.CartItem);
        }
        else
        {
            existingItem.Quantity += request.CartItem.Quantity;
        }

        await _redisRepository.Set(cartKey, JsonConvert.SerializeObject(cartItems));
        return true;
    }

    public async Task<bool> UpdateCartItem(UpdateCartRequest request)
    {
        var cartKey = $"cart:{request.UserId}";
        var cartJson = await _redisRepository.Get(cartKey);

        if (string.IsNullOrEmpty(cartJson)) return false;

        var cartItems = JsonConvert.DeserializeObject<List<CartItemDto>>(cartJson);
        var item = cartItems.FirstOrDefault(i => i.ProductId == request.ProductId);

        if (item != null)
        {
            if (request.Quantity <= 0)
            {
                cartItems.Remove(item);
            }
            else
            {
                item.Quantity = request.Quantity;
            }

            await _redisRepository.Set(cartKey, JsonConvert.SerializeObject(cartItems));
        }
        return true;
    }

    public async Task<bool> RemoveFromCart(string userId, Guid productId)
    {
        var cartKey = $"cart:{userId}";
        var cartJson = await _redisRepository.Get(cartKey);

        if (string.IsNullOrEmpty(cartJson)) return false;

        var cartItems = JsonConvert.DeserializeObject<List<CartItemDto>>(cartJson);
        cartItems.RemoveAll(i => i.ProductId == productId);

        await _redisRepository.Set(cartKey, JsonConvert.SerializeObject(cartItems));
        return true;
    }

    public async Task<List<CartItemDto>> GetCartItems(string userId)
    {
        var cartKey = $"cart:{userId}";
        var cartJson = await _redisRepository.Get(cartKey);

        if (string.IsNullOrEmpty(cartJson)) return new List<CartItemDto>();
        return JsonConvert.DeserializeObject<List<CartItemDto>>(cartJson);
    }

    public async Task<bool> ClearCart(string userId)
    {
        var cartKey = $"cart:{userId}";
        return await _redisRepository.Delete(cartKey);
    }
}
