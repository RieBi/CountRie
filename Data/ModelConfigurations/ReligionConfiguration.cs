using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfigurations;
internal class ReligionConfiguration : IEntityTypeConfiguration<Religion>
{
    public void Configure(EntityTypeBuilder<Religion> builder)
    {
        builder.Property(f => f.Name).HasMaxLength(DataConfig.NameLength);
        builder.Property(f => f.Description).HasMaxLength(DataConfig.DescriptionLength);

        builder.HasIndex(f => f.Name).IsUnique();

        builder.Property(f => f.Id)
            .UseIdentityAlwaysColumn();
    }
}
