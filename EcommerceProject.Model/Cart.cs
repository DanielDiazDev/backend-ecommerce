using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Model;

public class Cart
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public Guid ProductId { get; set; }
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    public UserAccount User { get; set; } //required
    public Product Product { get; set; } //required
}