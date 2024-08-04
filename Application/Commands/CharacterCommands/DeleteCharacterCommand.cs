namespace Application.Commands.CharacterCommands;
public record DeleteCharacterCommand(int Id) : IRequest<Unit>;
