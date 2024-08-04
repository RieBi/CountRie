namespace Application.Queries.CountryQueries;
internal class GetAllCountryNamesQueryHandler(DataContext context) : IRequestHandler<GetAllCountryNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;

    public async Task<IList<string>> Handle(GetAllCountryNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> result = await _context.Countries
            .Select(f => f.Name)
            .ToListAsync(cancellationToken);

        return result;
    }
}
