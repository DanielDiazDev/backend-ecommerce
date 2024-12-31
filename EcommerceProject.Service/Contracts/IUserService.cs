using EcommerceProject.Shared.Dtos;

namespace EcommerceProject.Service.Contracts;

public interface IUserService
{
    Task<bool> UpdateProfile(UpdateProfileDto updateProfileDto);
    Task<bool> ChangePassword(ChangePasswordDto changePasswordDto);
}