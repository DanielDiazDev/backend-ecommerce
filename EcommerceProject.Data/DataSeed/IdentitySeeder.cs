using EcommerceProject.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceProject.Data.DataSeed;

public static class IdentitySeeder
{
    public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<UserAccount>>();
        var adminRole = "Admin";
        var userRole = "User";
        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        if (!await roleManager.RoleExistsAsync(userRole))
        {
            await roleManager.CreateAsync(new IdentityRole(userRole));
        }
        var adminEmail = "admin@gmail.com";
        var adminPassword = "Admin123@";
        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var adminUser = new UserAccount
            {
                UserName = "Admin",
                Email = adminEmail,
                PasswordHash = adminPassword,
            };
            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
        }
    }
}