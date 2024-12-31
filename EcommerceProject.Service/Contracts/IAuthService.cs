using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.Service.Contracts;

public interface IAuthService
{
    Task<bool> RegisterUser(RegisterUserDto registerUserDto);
    Task<string> Authenticate(LoginUserDto loginUserDto);
}