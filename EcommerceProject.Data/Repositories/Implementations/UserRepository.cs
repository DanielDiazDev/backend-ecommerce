using EcommerceProject.Data.Repositories.Contracts;
using EcommerceProject.Model;

namespace EcommerceProject.Data.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Add(UserAccount userAccount, CancellationToken cancellationToken = default)
    {
        await _context.UserAccounts.AddAsync(userAccount, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
    
}