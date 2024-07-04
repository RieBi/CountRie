using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.ModelConfigurations;
internal class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder
            .HasOne(f => f.Language)
            .WithMany(f => f.Countries);

        builder
            .HasOne(f => f.Religion)
            .WithMany(f => f.Countries);

        builder
            .HasOne(f => f.GovernanceType)
            .WithMany(f => f.Countries);

        builder
            .HasMany(f => f.NaturalResources)
            .WithMany(f => f.Countries);

        builder
            .HasMany(f => f.Specialties)
            .WithMany(f => f.Countries);

        builder
            .HasMany(f => f.Characters)
            .WithOne(f => f.OriginCountry);

        builder.Property(f => f.Name).HasMaxLength(DataConfig.NameLength);
        builder.Property(f => f.Description).HasMaxLength(DataConfig.DescriptionLength);
        builder.Property(f => f.Capital).HasMaxLength(DataConfig.NameLength);
        builder.Property(f => f.FlagUrl).HasMaxLength(DataConfig.UrlLength);

        builder.HasIndex(f => f.Name).IsUnique();
    }
}
