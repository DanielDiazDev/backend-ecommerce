using Microsoft.AspNetCore.Identity;

namespace EcommerceProject.Model;

public class UserAccount : IdentityUser
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

    public ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
    public ICollection<Cart> Carts { get; set; } = new List<Cart>();

}