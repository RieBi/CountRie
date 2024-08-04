namespace Application.Commands.CharacterCommands;
public record EditCharacterCommand(int Id, CharacterCreateDto CharacterCreateDto) : IRequest<Unit>;
