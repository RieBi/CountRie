using Data.ModelConfigurations;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class DataContext(DbContextOptions<DataContext> options) : DbContext(options), IDataContext
{
    public DbSet<Battle> Battles { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<GovernanceType> GovernanceTypes { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<NaturalResource> NaturalResources { get; set; }
    public DbSet<Religion> Religions { get; set; }
    public DbSet<Specialty> Specialties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BattleConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new GovernanceTypeConfiguration());
        modelBuilder.ApplyConfiguration(new LanguageConfiguration());
        modelBuilder.ApplyConfiguration(new ReligionConfiguration());
        modelBuilder.ApplyConfiguration(new SpecialtyConfiguration());

        var dataSeeder = new DataSeeder(modelBuilder);
        dataSeeder.ApplySeeding();
    }
}
