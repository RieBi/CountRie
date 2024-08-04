namespace Application.Commands.CountryCommands;
public record EditCountryCommand(int Id, CountryCreateDto CountryCreateDto) : IRequest<Unit>;
