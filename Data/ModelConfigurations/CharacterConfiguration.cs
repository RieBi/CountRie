using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfigurations;
internal class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.HasOne(f => f.CurrentCountry);
        builder.HasOne(f => f.OriginCountry);

        builder.Property(f => f.Name).HasMaxLength(100);
        builder.Property(f => f.Description).HasMaxLength(5000);
    }
}
