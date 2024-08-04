namespace Application.Commands.NaturalResourceCommands;
internal class EditNaturalResourceCommandHandler(DataContext context) : IRequestHandler<EditNaturalResourceCommand, Unit>
{
    private readonly DataContext _context = context;

    public async Task<Unit> Handle(EditNaturalResourceCommand request, CancellationToken cancellationToken)
    {
        var existingResource = await _context.NaturalResources.FindAsync([request.Resource.Id], cancellationToken: cancellationToken);

        if (existingResource is null)
            return Unit.Value;

        existingResource.Name = request.Resource.Name;
        existingResource.Description = request.Resource.Description;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
