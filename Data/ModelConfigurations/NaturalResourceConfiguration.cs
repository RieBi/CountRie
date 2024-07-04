using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfigurations;
internal class NaturalResourceConfiguration : IEntityTypeConfiguration<NaturalResource>
{
    public void Configure(EntityTypeBuilder<NaturalResource> builder)
    {
        builder
            .HasMany(f => f.Countries)
            .WithMany(f => f.NaturalResources);

        builder.Property(f => f.Name).HasMaxLength(DataConfig.NameLength);
        builder.Property(f => f.Description).HasMaxLength(DataConfig.DescriptionLength);

        builder.HasIndex(f => f.Name).IsUnique();
    }
}
