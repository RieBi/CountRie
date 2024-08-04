namespace Application.Commands.NaturalResourceCommands;
internal class DeleteNaturalResourceCommandHandler(DataContext context) : IRequestHandler<DeleteNaturalResourceCommand, Unit>
{
    private readonly DataContext _context = context;

    public async Task<Unit> Handle(DeleteNaturalResourceCommand request, CancellationToken cancellationToken)
    {
        var resource = await _context.NaturalResources.FindAsync([request.Id], cancellationToken: cancellationToken);

        if (resource is null)
            return Unit.Value;

        _context.NaturalResources.Remove(resource);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
