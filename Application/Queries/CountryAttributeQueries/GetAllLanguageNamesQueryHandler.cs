namespace Application.Queries.CountryAttributeQueries;
public class GetAllLanguageNamesQueryHandler(DataContext context) : IRequestHandler<GetAllLanguageNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;

    public async Task<IList<string>> Handle(GetAllLanguageNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> result = await _context.Languages
            .Select(f => f.Name)
            .ToListAsync(cancellationToken);

        return result;
    }
}
