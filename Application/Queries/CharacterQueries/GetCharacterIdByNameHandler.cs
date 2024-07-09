
namespace Application.Queries.CharacterQueries;
public class GetCharacterIdByNameHandler(DataContext context) : IRequestHandler<GetCharacterIdByName, int?>
{
    private readonly DataContext _context = context;

    public Task<int?> Handle(GetCharacterIdByName request, CancellationToken cancellationToken)
    {
        var character = _context.Characters.SingleOrDefault(f => f.Name == request.Name);
        int? id = character?.Id;

        return Task.FromResult(id);
    }
}
