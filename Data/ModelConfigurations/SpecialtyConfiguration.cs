using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfigurations;
internal class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure(EntityTypeBuilder<Specialty> builder)
    {
        builder.Property(f => f.Name).HasMaxLength(DataConfig.NameLength);
        builder.Property(f => f.Description).HasMaxLength(DataConfig.DescriptionLength);
    }
}
