using Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Persistence.EntityConfigurations;

public class ProductManufacturerConfiguration : IEntityTypeConfiguration<ProductManufacturer>
{
    public void Configure(EntityTypeBuilder<ProductManufacturer> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Name).IsUnique();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
    }
}
