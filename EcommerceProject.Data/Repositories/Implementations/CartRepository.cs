using EcommerceProject.Data.Repositories.Contracts;
using EcommerceProject.Model;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Data.Repositories.Implementations;

public class CartRepository : ICartRepository
{
    private ApplicationDbContext _context;

    public CartRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // public async Task<bool> Add(Cart cart)
    // {
    //     await _context.Carts.AddAsync(cart);
    //     await _context.SaveChangesAsync();
    //     return true;
    // }

    // public async Task<Cart> Get(Guid cartId)
    // {
    //    // return await _context.Carts.FindAsync(cartId);
    // }
    //
    // public bool Update(Cart cart)
    // {
    //   //  _context.Entry(cart).State = EntityState.Modified;
    //     //_context.SaveChanges();
    //     return true;
    // }
    //
}