namespace Application.Commands.CharacterCommands;
public class DeleteCharacterCommandHandler(DataContext context) : IRequestHandler<DeleteCharacterCommand, Unit>
{
    private readonly DataContext _context = context;

    public async Task<Unit> Handle(DeleteCharacterCommand request, CancellationToken cancellationToken)
    {
        var characterToDelete = await _context.Characters.FindAsync([request.Id], cancellationToken: cancellationToken);

        if (characterToDelete is null)
            return Unit.Value;

        _context.Characters.Remove(characterToDelete);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
