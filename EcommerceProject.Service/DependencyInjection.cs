using EcommerceProject.Service.Contracts;
using EcommerceProject.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceProject.Service;

public static class DependencyInjection
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}

