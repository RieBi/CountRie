namespace Application.Commands.CountryCommands;
public class DeleteCountryCommand(int id) : IRequest<Unit>
{
    public int Id { get; } = id;
}
