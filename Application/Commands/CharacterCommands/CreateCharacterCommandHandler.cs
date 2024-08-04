using Application.Converters;
using Application.Services.UserManagement;

namespace Application.Commands.CharacterCommands;
internal class CreateCharacterCommandHandler(DataContext context, IUserInfoService userInfo) : IRequestHandler<CreateCharacterCommand, Result<int>>
{
    private readonly DataContext _context = context;
    private readonly IUserInfoService _userInfo = userInfo;

    public async Task<Result<int>> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = await new CharacterConverter(_context)
            .TryConvertFromDto(request.CharacterCreateDto, cancellationToken);

        if (character is null)
            return Result.Fail("Couldn't create a character");

        character.OwnerEmail = await _userInfo.GetUserEmailAsync(request.User);

        _context.Characters.Add(character);
        await _context.SaveChangesAsync(cancellationToken);

        return character.Id;
    }
}
