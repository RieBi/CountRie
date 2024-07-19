using Application.Converters;

namespace Application.Commands.CharacterCommands;
public class CreateCharacterCommandHandler(DataContext context) : IRequestHandler<CreateCharacterCommand, int>
{
    private readonly DataContext _context = context;

    public async Task<int> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = await new CharacterConverter(_context)
            .TryConvertFromDto(request.CharacterCreateDto, cancellationToken);

        if (character is null)
            return -1;

        await _context.Characters.AddAsync(character, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return character.Id;
    }
}
