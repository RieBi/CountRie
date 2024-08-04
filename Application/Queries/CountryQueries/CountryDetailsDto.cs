using Data.Models;

namespace Application.Queries.CountryQueries;
public class CountryDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string LongDescription { get; set; } = default!;
    public string Capital { get; set; } = default!;
    public long Population { get; set; }
    public long Area { get; set; }
    public GovernanceType GovernanceType { get; set; } = default!;
    public int IndependenceYear { get; set; }
    public Language Language { get; set; } = default!;
    public Religion Religion { get; set; } = default!;
    public string FlagUrl { get; set; } = default!;

    public ICollection<NaturalResource> NaturalResources { get; set; } = default!;
    public ICollection<Specialty> Specialties { get; set; } = default!;
    public ICollection<Character> Characters { get; set; } = default!;
}
