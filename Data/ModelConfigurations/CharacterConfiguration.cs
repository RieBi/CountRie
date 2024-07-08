using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfigurations;
internal class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder
            .HasOne(f => f.OriginCountry)
            .WithMany(f => f.Characters);

        builder
            .HasMany(f => f.WonBattles)
            .WithOne(f => f.WinnerCharacter);

        builder
            .HasMany(f => f.LostBattles)
            .WithOne(f => f.LoserCharacter);

        builder.Property(f => f.Name).HasMaxLength(DataConfig.NameLength);
        builder.Property(f => f.Description).HasMaxLength(DataConfig.DescriptionLength);
        builder.Property(f => f.PortraitUrl).HasMaxLength(DataConfig.UrlLength);
    }
}
