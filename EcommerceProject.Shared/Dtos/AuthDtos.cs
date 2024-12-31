namespace EcommerceProject.Shared.Dtos;

public record RegisterUserDto(string UserName, string Email, string Password);
public record LoginUserDto(string UserName, string Password);