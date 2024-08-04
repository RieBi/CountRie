using Data.Models;

namespace Application.Commands.NaturalResourceCommands;
public record CreateNaturalResourceCommand(NaturalResource Resource) : IRequest<int>;
