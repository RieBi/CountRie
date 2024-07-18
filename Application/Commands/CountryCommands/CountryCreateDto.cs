namespace Application.Commands.CountryCommands;
public class CountryCreateDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string LongDescription { get; set; } = default!;
    public string Capital { get; set; } = default!;
    public long Population { get; set; }
    public long Area { get; set; }
    public int IndependenceYear { get; set; }
    public string GovernanceTypeName { get; set; } = default!;
    public string LanguageName { get; set; } = default!;
    public string ReligionName { get; set; } = default!;
    public string FlagUrl { get; set; } = default!;

    public IList<string> NaturalResourceNames { get; set; } = default!;
    public IList<string> SpecialtyNames { get; set; } = default!;
}
