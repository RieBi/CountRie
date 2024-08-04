namespace Application.Queries.CountryQueries;
public record GetCountryIdByNameQuery(string Name) : IRequest<int>;
