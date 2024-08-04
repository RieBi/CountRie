namespace Application.Queries.CountryQueries;
public record GetCountryDetailsQuery(int Id) : IRequest<CountryDetailsDto?>;
