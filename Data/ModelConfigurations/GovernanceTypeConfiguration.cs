using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfigurations;
internal class GovernanceTypeConfiguration : IEntityTypeConfiguration<GovernanceType>
{
    public void Configure(EntityTypeBuilder<GovernanceType> builder)
    {
        builder.Property(f => f.Name).HasMaxLength(DataConfig.NameLength);
        builder.Property(f => f.Description).HasMaxLength(DataConfig.DescriptionLength);

        builder.HasIndex(f => f.Name).IsUnique();
    }
}
