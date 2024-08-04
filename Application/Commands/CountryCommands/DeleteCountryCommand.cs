namespace Application.Commands.CountryCommands;
public record DeleteCountryCommand(int Id) : IRequest<Unit>;
