using System.Security.Claims;

namespace Application.Commands.CountryCommands;
public class CreateCountryCommand(CountryCreateDto countryCreateDto, ClaimsPrincipal user) : IRequest<int>
{
    public CountryCreateDto CountryCreateDto { get; } = countryCreateDto;
    public ClaimsPrincipal User { get; } = user;
}
