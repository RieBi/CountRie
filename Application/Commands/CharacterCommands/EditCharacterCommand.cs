namespace Application.Commands.CharacterCommands;
public class EditCharacterCommand(int id, CharacterCreateDto characterCreateDto) : IRequest<Unit>
{
    public int Id { get; } = id;
    public CharacterCreateDto CharacterCreateDto { get; } = characterCreateDto;
}
