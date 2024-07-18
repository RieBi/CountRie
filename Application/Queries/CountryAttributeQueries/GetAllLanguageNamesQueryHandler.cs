namespace Application.Queries.CountryAttributeQueries;
public class GetAllLanguageNamesQueryHandler(DataContext context) : IRequestHandler<GetAllLanguageNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;

    public Task<IList<string>> Handle(GetAllLanguageNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> result = [.. _context.Languages.Select(f => f.Name)];

        return Task.FromResult(result);
    }
}
