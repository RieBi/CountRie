namespace Application.Queries.CountryList;
public class GetCountryDetailsQuery(string name) : IRequest<CountryDetailsDto?>
{
    public string Name { get; set; } = name;
}
