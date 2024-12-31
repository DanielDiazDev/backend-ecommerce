using EcommerceProject.Data.Configurations;
using EcommerceProject.Data.DataSeed;
using EcommerceProject.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new RoleSeed());
        builder.ApplyConfiguration(new AdminSeed());
        builder.ApplyConfiguration(new CategorySeed());
        builder.ApplyConfiguration(new ProductSeed());
        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
}