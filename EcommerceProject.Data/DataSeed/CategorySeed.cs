using EcommerceProject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceProject.Data.DataSeed;

public class CategorySeed : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        try
        {
            builder.HasData(
                new Category { Id = Guid.Parse("6f1392c0-bf53-4e79-b20f-d019f0c257ad"), Name = "Electronics", Description = "Electronics category" },
                new Category { Id = Guid.Parse("f97f6d3d-60f3-4886-9cae-e2eb3e5c43c8"), Name = "Clothing", Description = "Clothing category" });
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}