using Data.Models;

namespace Application.Commands.SpecialtyCommands;
public class CreateSpecialtyCommand(Specialty specialty) : IRequest<int>
{
    public Specialty Specialty { get; } = specialty;
}
