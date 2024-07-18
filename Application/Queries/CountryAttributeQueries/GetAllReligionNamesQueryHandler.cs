namespace Application.Queries.CountryAttributeQueries;
public class GetAllReligionNamesQueryHandler(DataContext context) : IRequestHandler<GetAllReligionNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;

    public Task<IList<string>> Handle(GetAllReligionNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> result = [.. _context.Religions.Select(f => f.Name)];

        return Task.FromResult(result);
    }
}
