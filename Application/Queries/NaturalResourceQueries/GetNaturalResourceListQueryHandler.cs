using Data.Models;

namespace Application.Queries.NaturalResourceQueries;
public class GetNaturalResourceListQueryHandler(DataContext context) : IRequestHandler<GetNaturalResourceListQuery, IList<NaturalResource>>
{
    private readonly DataContext _context = context;

    public Task<IList<NaturalResource>> Handle(GetNaturalResourceListQuery request, CancellationToken cancellationToken)
    {
        var resources = _context.NaturalResources;

        IList<NaturalResource> resourceList = resources.ToList();

        return Task.FromResult(resourceList);
    }
}
