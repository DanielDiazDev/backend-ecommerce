using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EcommerceProject.Data.Repositories.Contracts;
using EcommerceProject.Model;
using EcommerceProject.Service.Contracts;
using EcommerceProject.Shared.Configurations;
using EcommerceProject.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceProject.Service.Implementations;

public class AuthService : IAuthService
{
    private IUserRepository _userRepository;
    private UserManager<UserAccount> _userManager;
    private SignInManager<UserAccount> _signInManager;
    private IMapper _mapper;
    private readonly JwtSettings _jwtSettings;
    public AuthService(IUserRepository userRepository, UserManager<UserAccount> userManager, IMapper mapper, IOptions<JwtSettings> jwtSettings, SignInManager<UserAccount> signInManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<bool> RegisterUser(RegisterUserDto registerUserDto)
    {
        var user = _mapper.Map<UserAccount>(registerUserDto);
        var result = await _userManager.CreateAsync(user, registerUserDto.Password);
        var roleAdded = await _userManager.AddToRoleAsync(user, "User");

        return true;
    }

    public async Task<string> Authenticate(LoginUserDto loginUserDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, false, false);
        if (!result.Succeeded)
        {
            return null;
        }

        var user = await _userManager.FindByNameAsync(loginUserDto.UserName);
        if (user == null)
        {
            return null;
        }
        var token = GenerateJwtToken(user);
        return token;
    }
    
    private string GenerateJwtToken(UserAccount user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}