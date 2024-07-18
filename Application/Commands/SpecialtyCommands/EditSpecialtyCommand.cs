using Data.Models;

namespace Application.Commands.SpecialtyCommands;
public class EditSpecialtyCommand(Specialty specialty) : IRequest<Unit>
{
    public Specialty Specialty { get; } = specialty;
}
