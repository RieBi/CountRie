namespace Application.Queries.CountryAttributeQueries;
public class GetAllReligionNamesQueryHandler(DataContext context) : IRequestHandler<GetAllReligionNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;

    public async Task<IList<string>> Handle(GetAllReligionNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> result = await _context.Religions
            .Select(f => f.Name)
            .ToListAsync(cancellationToken);

        return result;
    }
}
