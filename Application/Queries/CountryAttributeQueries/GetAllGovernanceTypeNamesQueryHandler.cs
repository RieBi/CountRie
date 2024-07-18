namespace Application.Queries.CountryAttributeQueries;
public class GetAllGovernanceTypeNamesQueryHandler(DataContext context) : IRequestHandler<GetAllGovernanceTypeNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;

    public Task<IList<string>> Handle(GetAllGovernanceTypeNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> result = [.. _context.GovernanceTypes.Select(f => f.Name)];

        return Task.FromResult(result);
    }
}
