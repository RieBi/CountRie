namespace Application.Commands.SpecialtyCommands;
public class DeleteSpecialtyCommand(int id) : IRequest<Unit>
{
    public int Id { get; } = id;
}
