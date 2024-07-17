namespace Application.Commands.NaturalResourceCommands;
public class DeleteNaturalResourceCommand(int id) : IRequest<Unit>
{
    public int Id { get; } = id;
}
