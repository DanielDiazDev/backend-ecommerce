namespace EcommerceProject.Model;

public class Order
{
    public enum PaytStatu
    {
        Pending,
        Success,
        Failure,
        Canceled
    }
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    public PaytStatu PaymentStatus { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public UserAccount User { get; set; }
    
    
}