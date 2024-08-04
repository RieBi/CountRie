namespace Application.Commands.SpecialtyCommands;
internal class DeleteSpecialtyCommandHandler(DataContext context) : IRequestHandler<DeleteSpecialtyCommand, Unit>
{
    private readonly DataContext _context = context;

    public async Task<Unit> Handle(DeleteSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var specialty = await _context.Specialties.FindAsync([request.Id], cancellationToken: cancellationToken);

        if (specialty is null)
            return Unit.Value;

        _context.Specialties.Remove(specialty);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
