using Application.Commands.CountryCommands;

namespace Application.Queries.CountryQueries;
public record GetCountryCreateDtoQuery(int Id) : IRequest<CountryCreateDto?>;
