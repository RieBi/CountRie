using Data.Models;

namespace Application.Commands.NaturalResourceCommands;
public class EditNaturalResourceCommand(NaturalResource naturalResource) : IRequest<Unit>
{
    public NaturalResource Resource { get; } = naturalResource;
}
