namespace Application.Commands.CharacterCommands;
public class CreateCharacterCommand(CharacterCreateDto characterCreateDto) : IRequest<int>
{
    public CharacterCreateDto CharacterCreateDto { get; } = characterCreateDto;
}
