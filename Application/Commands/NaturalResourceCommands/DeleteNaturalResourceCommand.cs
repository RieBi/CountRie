namespace Application.Commands.NaturalResourceCommands;
public record DeleteNaturalResourceCommand(int Id) : IRequest<Unit>;
