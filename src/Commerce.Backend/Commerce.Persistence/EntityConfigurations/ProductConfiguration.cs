using Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.IdentificationNumber).IsUnique();

        builder.Property(p => p.MetaTitle).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Model).HasMaxLength(100);
        builder.Property(p => p.Link).HasMaxLength(255);
        builder.Property(p => p.MetaTags).HasMaxLength(255);
        builder.Property(p => p.MetaDescription).HasMaxLength(500);
        builder.Property(p => p.Description).HasMaxLength(1000);
        builder.Property(p => p.ImageUrl).HasMaxLength(500);

        builder.HasOne(p => p.ProductManufacturer)
               .WithMany(m => m.Products)
               .HasForeignKey(p => p.ProductManufacturerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Section)
               .WithMany(s => s.Products)
               .HasForeignKey(p => p.SectionId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Country)
               .WithMany()
               .HasForeignKey(p => p.CountryId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}