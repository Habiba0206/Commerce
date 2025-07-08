using Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Persistence.EntityConfigurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasOne(s => s.Product)
               .WithMany(p => p.Sales)
               .HasForeignKey(s => s.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s => s.QuantitySold).IsRequired();
        builder.Property(s => s.SalePrice).IsRequired();
        builder.Property(s => s.SaleDate).IsRequired();
    }
}
