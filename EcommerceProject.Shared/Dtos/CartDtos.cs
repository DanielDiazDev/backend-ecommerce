namespace EcommerceProject.Shared.Dtos;

public record CartItemDto(Guid ProductId, decimal Price)
{
    public int Quantity { get; set; }
};
public record AddToCartRequest(string UserId, CartItemDto CartItem);
public record UpdateCartRequest(string UserId, Guid ProductId, int Quantity);