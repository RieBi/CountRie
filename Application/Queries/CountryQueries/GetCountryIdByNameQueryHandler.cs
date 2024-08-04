namespace Application.Queries.CountryQueries;
internal class GetCountryIdByNameQueryHandler(DataContext context) : IRequestHandler<GetCountryIdByNameQuery, int>
{
    private readonly DataContext _context = context;

    public Task<int> Handle(GetCountryIdByNameQuery request, CancellationToken cancellationToken)
    {
        var result = _context.Countries
            .Where(f => f.Name == request.Name)
            .Select(f => f.Id)
            .AsEnumerable()
            .SingleOrDefault(-1);

        return Task.FromResult(result);
    }
}
