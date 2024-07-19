using Application.Converters;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.CharacterCommands;
public class EditCharacterCommandHandler(DataContext context) : IRequestHandler<EditCharacterCommand, Unit>
{
    private readonly DataContext _context = context;

    public async Task<Unit> Handle(EditCharacterCommand request, CancellationToken cancellationToken)
    {
        var character = await _context.Characters
            .Where(f => f.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (character is null)
            return Unit.Value;

        character = await new CharacterConverter(_context)
            .TryConvertFromDto(request.characterCreateDto, cancellationToken, character);

        if (character is null)
            return Unit.Value;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
