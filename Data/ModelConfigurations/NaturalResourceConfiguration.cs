using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfigurations;
internal class NaturalResourceConfiguration : IEntityTypeConfiguration<NaturalResource>
{
    public void Configure(EntityTypeBuilder<NaturalResource> builder)
    {
        builder.Property(f => f.Name).HasMaxLength(DataConfig.NameLength);
        builder.Property(f => f.Description).HasMaxLength(DataConfig.DescriptionLength);
    }
}
