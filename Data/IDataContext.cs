using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;
public interface IDataContext
{
    DbSet<Battle> Battles { get; set; }
    DbSet<Character> Characters { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<GovernanceType> GovernanceTypes { get; set; }
    DbSet<Language> Languages { get; set; }
    DbSet<NaturalResource> NaturalResources { get; set; }
    DbSet<Religion> Religions { get; set; }
    DbSet<Specialty> Specialties { get; set; }
}