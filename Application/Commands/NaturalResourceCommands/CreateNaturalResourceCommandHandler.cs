using Data.Models;

namespace Application.Commands.NaturalResourceCommands;
public class CreateNaturalResourceCommandHandler(DataContext context) : IRequestHandler<CreateNaturalResourceCommand, int>
{
    private readonly DataContext _context = context;

    public async Task<int> Handle(CreateNaturalResourceCommand request, CancellationToken cancellationToken)
    {
        await _context.NaturalResources.AddAsync(request.Resource, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return request.Resource.Id;
    }
}
