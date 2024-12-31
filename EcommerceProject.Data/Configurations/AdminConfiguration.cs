using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceProject.Data.Configurations;

public class AdminConfiguration 
{
    // public void Configure(EntityTypeBuilder<IdentityUser> builder)
    // {
    //     const string adminEmail = "admin@gmail.com";
    //     const string adminPassword = "Admin123@";
    //     const string userName = "Admin";
    //
    //     var hasher = new PasswordHasher<IdentityUser>();
    //     var adminUser = new IdentityUser
    //     {
    //         UserName = userName,
    //         Email = adminEmail,
    //     };
    //     adminUser.PasswordHash = hasher.HashPassword(adminUser, adminPassword);
    //     builder.HasData(adminUser);
    // }
}