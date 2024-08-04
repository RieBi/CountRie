using Data.Models;

namespace Application.Queries.NaturalResourceQueries;
public class GetNaturalResourceListQueryHandler(DataContext context) : IRequestHandler<GetNaturalResourceListQuery, IList<NaturalResource>>
{
    private readonly DataContext _context = context;

    public async Task<IList<NaturalResource>> Handle(GetNaturalResourceListQuery request, CancellationToken cancellationToken)
    {
        var resources = await _context.NaturalResources
            .ToListAsync(cancellationToken);

        return resources;
    }
}
