using EcommerceProject.Data.Repositories.Contracts;
using EcommerceProject.Model;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Data.Repositories.Implementations;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Order> GetOrderById(Guid orderId)
    {
        return await _context.Orders
            .Include(o => o.OrderDetails)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }

    public async Task<bool> Add(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Order>> GetOrdersByUser(string userId)
    {
        return await _context.Orders
            .Include(o => o.OrderDetails)
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }

    public bool UpdateOrderStatus(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        _context.SaveChanges();
        return true;
    }
}