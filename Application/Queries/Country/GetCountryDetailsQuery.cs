namespace Application.Queries.Country;
public class GetCountryDetailsQuery(string name) : IRequest<CountryDetailsDto?>
{
    public string Name { get; set; } = name;
}
