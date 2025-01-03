namespace EcommerceProject.Data.Repositories.Contracts;

public interface IRedisRepository
{
    Task<string> Get(string key);
    Task<bool> Set(string key, string value);
    Task<bool> Delete(string key);
    Task<bool> KeyExists(string key);
}