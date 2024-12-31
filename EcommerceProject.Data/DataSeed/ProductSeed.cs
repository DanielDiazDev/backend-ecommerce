using EcommerceProject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceProject.Data.DataSeed;

public class ProductSeed : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        try
        {
            builder.HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone",
                    Description = "High-end smartphone with OLED display",
                    Price = 699.99m,
                    Stock = 50,
                    CategoryId = Guid.Parse("6f1392c0-bf53-4e79-b20f-d019f0c257ad") // Electronic category
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop",
                    Description = "Powerful laptop for gaming and work",
                    Price = 1199.99m,
                    Stock = 30,
                    CategoryId = Guid.Parse("6f1392c0-bf53-4e79-b20f-d019f0c257ad") // Electronic category
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "T-Shirt",
                    Description = "Comfortable cotton T-shirt",
                    Price = 19.99m,
                    Stock = 200,
                    CategoryId = Guid.Parse("f97f6d3d-60f3-4886-9cae-e2eb3e5c43c8") // Clothing category
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Jeans",
                    Description = "Stylish denim jeans",
                    Price = 49.99m,
                    Stock = 100,
                    CategoryId = Guid.Parse("f97f6d3d-60f3-4886-9cae-e2eb3e5c43c8") // Clothing category
                }
            );
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}