using EcommerceProject.Service.Contracts;
using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.API.Endpoints;

public static class AuthModule
{
    public static void AddAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("RegisterUser", async (RegisterUserDto registerUserDto, IAuthService authService) =>
        {
            var result = await authService.RegisterUser(registerUserDto);
            return Results.Ok(result);
        });
        app.MapPost("LoginUser", async (LoginUserDto loginUserDto, IAuthService authService) =>
        {
            var result = await authService.Authenticate(loginUserDto);
            return Results.Ok(result);
        });
        //Autenticacion de usuario
    }
    
}