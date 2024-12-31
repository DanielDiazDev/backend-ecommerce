using EcommerceProject.Model;

namespace EcommerceProject.Data.Repositories.Contracts;

public interface IProductRepository
{
    Task<bool> Add(Product product);
}