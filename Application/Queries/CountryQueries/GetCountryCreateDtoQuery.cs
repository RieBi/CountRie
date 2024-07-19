using Application.Commands.CountryCommands;

namespace Application.Queries.CountryQueries;
public class GetCountryCreateDtoQuery(int id) : IRequest<CountryCreateDto?>
{
    public int Id { get; } = id;
}
