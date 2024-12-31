namespace EcommerceProject.Model;

public class Wishlist
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public Guid ProductId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public UserAccount User { get; set; } //required
    public Product Product { get; set; } //required
}