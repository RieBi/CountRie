namespace Application.Queries.CharacterQueries;
public class GetAllCharactersQueryHandler(DataContext context) : IRequestHandler<GetAllCharacterNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;


    public async Task<IList<string>> Handle(GetAllCharacterNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> characters = await _context.Characters
            .Select(f => f.Name)
            .ToListAsync(cancellationToken);

        return characters;
    }
}
