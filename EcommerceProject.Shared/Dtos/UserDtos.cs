namespace EcommerceProject.Shared.Dtos;

public record UpdateProfileDto(string Id, string UserName, string Email);
public record ChangePasswordDto(string Id, string OldPassword, string NewPassword);