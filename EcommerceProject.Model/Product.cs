using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Model;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public Guid CategoryId { get; set; }

    public Product()
    {
        CreatedDate = DateTime.Now;
        ModifiedDate = DateTime.Now;
    }
    
    public Category Category { get; set; } //required
}
