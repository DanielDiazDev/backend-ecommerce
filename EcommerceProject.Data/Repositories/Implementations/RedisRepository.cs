using EcommerceProject.Data.Repositories.Contracts;
using EcommerceProject.Shared.Redis;
using StackExchange.Redis;

namespace EcommerceProject.Data.Repositories.Implementations;

public class RedisRepository : IRedisRepository
{
    private readonly IDatabase _database;

    public RedisRepository()
    {
        _database = RedisDb.Connection.GetDatabase();
    }

    public async Task<string> Get(string key)
    {
        return await _database.StringGetAsync(key);
    }

    public async Task<bool> Set(string key, string value)
    {
        return await _database.StringSetAsync(key, value);
    }

    public async Task<bool> Delete(string key)
    {
        return await _database.KeyDeleteAsync(key);
    }

    public async Task<bool> KeyExists(string key)
    {
        return await _database.KeyExistsAsync(key);
    }
}