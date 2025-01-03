using EcommerceProject.Model;

namespace EcommerceProject.Data.Repositories.Contracts;

public interface IOrderRepository
{
    Task<Order> GetOrderById(Guid orderId);
    Task<bool> Add(Order order);
    Task<List<Order>> GetOrdersByUser(string userId);
    bool UpdateOrderStatus(Order order);
}