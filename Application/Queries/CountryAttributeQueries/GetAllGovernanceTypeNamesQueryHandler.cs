namespace Application.Queries.CountryAttributeQueries;
public class GetAllGovernanceTypeNamesQueryHandler(DataContext context) : IRequestHandler<GetAllGovernanceTypeNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;

    public async Task<IList<string>> Handle(GetAllGovernanceTypeNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> result = await _context.GovernanceTypes
            .Select(f => f.Name)
            .ToListAsync(cancellationToken);

        return result;
    }
}
