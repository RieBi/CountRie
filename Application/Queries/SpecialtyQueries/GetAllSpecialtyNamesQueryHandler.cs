namespace Application.Queries.SpecialtyQueries;
public class GetAllSpecialtyNamesQueryHandler(DataContext context) : IRequestHandler<GetAllSpecialtyNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;

    public async Task<IList<string>> Handle(GetAllSpecialtyNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> result = await _context.Specialties
            .Select(f => f.Name)
            .ToListAsync(cancellationToken);

        return result;
    }
}
