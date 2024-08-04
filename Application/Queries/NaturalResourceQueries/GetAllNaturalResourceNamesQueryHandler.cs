namespace Application.Queries.NaturalResourceQueries;
public class GetAllNaturalResourceNamesQueryHandler(DataContext context) : IRequestHandler<GetAllNaturalResourceNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;

    public async Task<IList<string>> Handle(GetAllNaturalResourceNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> result = await _context.NaturalResources
            .Select(f => f.Name)
            .ToListAsync(cancellationToken);

        return result;
    }
}
