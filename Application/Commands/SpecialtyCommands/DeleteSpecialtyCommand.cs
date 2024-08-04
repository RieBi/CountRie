namespace Application.Commands.SpecialtyCommands;
public record DeleteSpecialtyCommand(int Id) : IRequest<Unit>;
