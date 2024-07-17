namespace Application.Commands.NaturalResourceCommands;
public class DeleteNaturalResourceCommandHandler(DataContext context) : IRequestHandler<DeleteNaturalResourceCommand, Unit>
{
    private readonly DataContext _context = context;

    public Task<Unit> Handle(DeleteNaturalResourceCommand request, CancellationToken cancellationToken)
    {
        var resource = _context.NaturalResources.Find(request.Id);

        if (resource is null)
            return Unit.Task;

        _context.NaturalResources.Remove(resource);

        return Unit.Task;
    }
}
