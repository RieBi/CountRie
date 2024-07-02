using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfigurations;
internal class BattleConfiguration : IEntityTypeConfiguration<Battle>
{
    public void Configure(EntityTypeBuilder<Battle> builder)
    {
        builder.HasOne(f => f.WinnerCharacter);
        builder.HasOne(f => f.LoserCharacter);
        builder.HasOne(f => f.Country);

        builder.Property(f => f.Name).HasMaxLength(DataConfig.NameLength);
    }
}
