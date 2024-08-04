using Data.Models;

namespace Application.Commands.SpecialtyCommands;
public record EditSpecialtyCommand(Specialty Specialty) : IRequest<Unit>;
