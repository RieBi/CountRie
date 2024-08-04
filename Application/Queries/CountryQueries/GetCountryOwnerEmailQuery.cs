namespace Application.Queries.CountryQueries;
public record GetCountryOwnerEmailQuery(int CountryId) : IRequest<string?>;
