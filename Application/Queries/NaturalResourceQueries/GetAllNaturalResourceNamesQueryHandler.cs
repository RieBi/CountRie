namespace Application.Queries.NaturalResourceQueries;
public class GetAllNaturalResourceNamesQueryHandler(DataContext context) : IRequestHandler<GetAllNaturalResourceNamesQuery, IList<string>>
{
    private readonly DataContext _context = context;

    public Task<IList<string>> Handle(GetAllNaturalResourceNamesQuery request, CancellationToken cancellationToken)
    {
        IList<string> result = [.. _context.NaturalResources.Select(f => f.Name)];

        return Task.FromResult(result);
    }
}
