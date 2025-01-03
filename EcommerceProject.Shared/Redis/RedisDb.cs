using StackExchange.Redis;

namespace EcommerceProject.Shared.Redis;

public class RedisDb
{
    private static Lazy<ConnectionMultiplexer> _lazyConnection;
    public static ConnectionMultiplexer Connection => _lazyConnection.Value;

    static RedisDb()
    {
        _lazyConnection = new Lazy<ConnectionMultiplexer>(() => 
            ConnectionMultiplexer.Connect("localhost"));
    }
}