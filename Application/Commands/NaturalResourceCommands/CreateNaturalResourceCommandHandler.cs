using Data.Models;

namespace Application.Commands.NaturalResourceCommands;
internal class CreateNaturalResourceCommandHandler(DataContext context) : IRequestHandler<CreateNaturalResourceCommand, int>
{
    private readonly DataContext _context = context;

    public async Task<int> Handle(CreateNaturalResourceCommand request, CancellationToken cancellationToken)
    {
        _context.NaturalResources.Add(request.Resource);
        await _context.SaveChangesAsync(cancellationToken);

        return request.Resource.Id;
    }
}
