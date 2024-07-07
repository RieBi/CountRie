using Data.Models;

namespace Application.Queries.CountryQueries;
public class CountryListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public GovernanceType GovernanceType { get; set; } = default!;
    public Language Language { get; set; } = default!;
    public Religion Religion { get; set; } = default!;
    public string FlagUrl { get; set; } = default!;
}
