using System.Text;
using Microsoft.Extensions.Configuration;

namespace EcommerceProject.Data.Configurations;

public static class SqlServerConfiguration
{
    public static string BuildConnectionString(IConfiguration configuration)
    {
        var databaseConfig = new DatabaseConfig();
        configuration.Bind("SqlServerConnection", databaseConfig);
        var sb = new StringBuilder();
        sb.Append($"Server={databaseConfig.Server};");
        sb.Append($"Database={databaseConfig.Database};");
        sb.Append($"User Id={databaseConfig.UserId};");
        sb.Append($"Password={databaseConfig.Password};");
        sb.Append($"Trusted_Connection={databaseConfig.TrustedConnection};");
        sb.Append($"TrustServerCertificate={databaseConfig.TrustServerCertificate};");
        return sb.ToString();
    }
}