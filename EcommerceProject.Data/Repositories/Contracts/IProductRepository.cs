using EcommerceProject.Model;

namespace EcommerceProject.Data.Repositories.Contracts;

public interface IProductRepository
{
    Task<bool> Add(Product product);
    IQueryable<Product> GetAll();
    Task<Product> Get(Guid id);
}