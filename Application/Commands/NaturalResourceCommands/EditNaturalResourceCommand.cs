using Data.Models;

namespace Application.Commands.NaturalResourceCommands;
public record EditNaturalResourceCommand(NaturalResource Resource) : IRequest<Unit>;
