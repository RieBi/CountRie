namespace Application.Queries.CharacterQueries;
internal class GetCharacterIdByNameQueryHandler(DataContext context) : IRequestHandler<GetCharacterIdByNameQuery, Result<int>>
{
    private readonly DataContext _context = context;

    public async Task<Result<int>> Handle(GetCharacterIdByNameQuery request, CancellationToken cancellationToken)
    {
        var ids = await _context.Characters
            .Where(f => f.Name == request.Name)
            .Select(f => f.Id)
            .ToListAsync(cancellationToken);

        if (ids.Count > 0)
            return ids[0];
        else
            return Result.Fail("Character not found");
    }
}
