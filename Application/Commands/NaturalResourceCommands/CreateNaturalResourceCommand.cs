using Data.Models;

namespace Application.Commands.NaturalResourceCommands;
public class CreateNaturalResourceCommand(NaturalResource resource) : IRequest<int>
{
    public NaturalResource Resource { get; } = resource;
}
