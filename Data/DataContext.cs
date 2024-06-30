using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class DataContext : DbContext, IDataContext
{
    public DbSet<Battle> Battles { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<GovernanceType> GovernanceTypes { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<NaturalResource> NaturalResources { get; set; }
    public DbSet<Religion> Religions { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
}
