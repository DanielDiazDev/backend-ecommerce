using EcommerceProject.Model;
using EcommerceProject.Service.Contracts;
using EcommerceProject.Shared.Dtos;
using Microsoft.AspNetCore.Identity;

namespace EcommerceProject.Service.Implementations;

public class UserService : IUserService
{
    private UserManager<UserAccount> _userManager;

    public UserService(UserManager<UserAccount> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> UpdateProfile(UpdateProfileDto updateProfileDto)
    {
        var user = await _userManager.FindByIdAsync(updateProfileDto.Id);
        user.UserName = updateProfileDto.UserName;
        user.Email = updateProfileDto.Email;
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded;
    }

    public async Task<bool> ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var user = await _userManager.FindByIdAsync(changePasswordDto.Id);
        var isOldPassword = await _userManager.CheckPasswordAsync(user, changePasswordDto.OldPassword);
        if (!isOldPassword) return false;
        var result = await _userManager.ChangePasswordAsync(user, changePasswordDto.OldPassword, changePasswordDto.NewPassword);
        return result.Succeeded;

    }
}