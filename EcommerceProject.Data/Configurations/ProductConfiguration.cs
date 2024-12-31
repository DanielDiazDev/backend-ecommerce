using EcommerceProject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceProject.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasIndex(p=>p.Name)
            .IsUnique();
        builder.Property(p=>p.Price)
            .HasColumnType("decimal(18,2)");
        builder.Property(p => p.Description)
            .HasColumnType("varchar(500)");
    }
}