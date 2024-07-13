using Data.ModelConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Battle> Battles { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<GovernanceType> GovernanceTypes { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<NaturalResource> NaturalResources { get; set; }
    public DbSet<Religion> Religions { get; set; }
    public DbSet<Specialty> Specialties { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new BattleConfiguration());
        builder.ApplyConfiguration(new CharacterConfiguration());
        builder.ApplyConfiguration(new CountryConfiguration());
        builder.ApplyConfiguration(new GovernanceTypeConfiguration());
        builder.ApplyConfiguration(new LanguageConfiguration());
        builder.ApplyConfiguration(new ReligionConfiguration());
        builder.ApplyConfiguration(new SpecialtyConfiguration());
    }
}
