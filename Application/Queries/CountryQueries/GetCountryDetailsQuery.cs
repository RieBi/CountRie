namespace Application.Queries.CountryQueries;
public class GetCountryDetailsQuery(string name) : IRequest<CountryDetailsDto?>
{
    public string Name { get; set; } = name;
}
