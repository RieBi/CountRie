using System.Security.Claims;

namespace Application.Commands.CharacterCommands;
public record CreateCharacterCommand(CharacterCreateDto CharacterCreateDto, ClaimsPrincipal User) : IRequest<int>;
