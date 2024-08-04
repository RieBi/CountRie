using System.Security.Claims;

namespace Application.Commands.CountryCommands;
public record CreateCountryCommand(CountryCreateDto CountryCreateDto, ClaimsPrincipal User) : IRequest<int>;
