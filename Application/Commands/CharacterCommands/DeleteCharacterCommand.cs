namespace Application.Commands.CharacterCommands;
public class DeleteCharacterCommand(int id) : IRequest<Unit>
{
    public int Id { get; } = id;
}
