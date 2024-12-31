using EcommerceProject.Service.Contracts;
using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.API.Endpoints;

public static class UserModule
{
    public static void AddUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPut("UpdateProfile", async (UpdateProfileDto updateProfileDto, IUserService userService) =>
        {
            var result = await userService.UpdateProfile(updateProfileDto);
            return Results.Ok(result);
        });
        app.MapPut("ChangePassword", async (ChangePasswordDto changePasswordDto, IUserService userService) =>
        {
            var result = await userService.ChangePassword(changePasswordDto);
            return Results.Ok(result);
        });
    }
}