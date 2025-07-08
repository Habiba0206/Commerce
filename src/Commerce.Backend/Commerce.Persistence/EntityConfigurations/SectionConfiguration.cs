using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Commerce.Domain.Entities;

namespace Commerce.Persistence.EntityConfigurations;

public class SectionConfiguration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.HasKey(s => s.Id);
        builder.HasIndex(s => s.Name).IsUnique();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
    }
}