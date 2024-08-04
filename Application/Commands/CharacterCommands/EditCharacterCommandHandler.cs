using Application.Converters;

namespace Application.Commands.CharacterCommands;
internal class EditCharacterCommandHandler(DataContext context) : IRequestHandler<EditCharacterCommand, Unit>
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
            .TryConvertFromDto(request.CharacterCreateDto, cancellationToken, character);

        if (character is null)
            return Unit.Value;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
