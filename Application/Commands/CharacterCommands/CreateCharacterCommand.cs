using System.Security.Claims;

namespace Application.Commands.CharacterCommands;
public class CreateCharacterCommand(CharacterCreateDto characterCreateDto, ClaimsPrincipal user) : IRequest<int>
{
    public CharacterCreateDto CharacterCreateDto { get; } = characterCreateDto;
    public ClaimsPrincipal User { get; } = user;
}
