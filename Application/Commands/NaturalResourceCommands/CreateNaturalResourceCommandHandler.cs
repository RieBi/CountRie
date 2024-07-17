namespace Application.Commands.NaturalResourceCommands;
public class CreateNaturalResourceCommandHandler(DataContext context) : IRequestHandler<CreateNaturalResourceCommand, int>
{
    private readonly DataContext _context = context;

    public async Task<int> Handle(CreateNaturalResourceCommand request, CancellationToken cancellationToken)
    {
        var newResource = await _context.NaturalResources.AddAsync(request.Resource, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return newResource.Entity.Id;
    }
}
