namespace Application.Queries.SpecialtyQueries;
public class GetAllSpecialtyNamesQueryHandler(DataContext context) : IRequestHandler<GetAllSpecialtyNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;

    public Task<IList<string>> Handle(GetAllSpecialtyNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> result = [.. _context.Specialties.Select(f => f.Name)];

        return Task.FromResult(result);
    }
}
