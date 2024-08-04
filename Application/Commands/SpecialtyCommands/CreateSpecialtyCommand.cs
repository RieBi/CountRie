using Data.Models;

namespace Application.Commands.SpecialtyCommands;
public record CreateSpecialtyCommand(Specialty Specialty) : IRequest<int>;
