namespace Application.Queries.CountryQueries;
public class GetAllCountryNamesQueryHandler(DataContext context) : IRequestHandler<GetAllCountryNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;

    public Task<IList<string>> Handle(GetAllCountryNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> result = [.. _context.Countries.Select(f => f.Name)];

        return Task.FromResult(result);
    }
}
