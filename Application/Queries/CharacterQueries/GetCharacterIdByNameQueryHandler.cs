namespace Application.Queries.CharacterQueries;
public class GetCharacterIdByNameQueryHandler(DataContext context) : IRequestHandler<GetCharacterIdByNameQuery, int>
{
    private readonly DataContext _context = context;

    public Task<int> Handle(GetCharacterIdByNameQuery request, CancellationToken cancellationToken)
    {
        var id = _context.Characters
            .Where(f => f.Name == request.Name)
            .Select(f => f.Id)
            .AsEnumerable()
            .SingleOrDefault(-1);

        return Task.FromResult(id);
    }
}
