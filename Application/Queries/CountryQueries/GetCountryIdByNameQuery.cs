namespace Application.Queries.CountryQueries;
public class GetCountryIdByNameQuery(string name) : IRequest<int>
{
    public string Name { get; } = name;
}
