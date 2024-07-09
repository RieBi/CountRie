namespace Application.Queries.CharacterQueries;
public class GetAllCharactersQueryHandler(DataContext context) : IRequestHandler<GetAllCharacterNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;


    public Task<IList<string>> Handle(GetAllCharacterNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> characters = [.. _context.Characters.Select(f => f.Name)];

        return Task.FromResult(characters);
    }
}
