using EcommerceProject.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceProject.Data.DataSeed;

public class AdminSeed : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        const string adminEmail = "admin@gmail.com";
        const string adminPassword = "Admin123@";
        const string userName = "Admin";

        var hasher = new PasswordHasher<UserAccount>();
        var adminUser = new UserAccount
        {
            UserName = userName,
            Email = adminEmail,
        };
        adminUser.PasswordHash = hasher.HashPassword(adminUser, adminPassword);
        builder.HasData(adminUser);
    }
}