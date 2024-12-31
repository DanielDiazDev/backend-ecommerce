using EcommerceProject.Model;

namespace EcommerceProject.Data.Repositories.Contracts;

public interface IUserRepository
{
    Task<bool> Add(UserAccount userAccount, CancellationToken cancellationToken = default);
}