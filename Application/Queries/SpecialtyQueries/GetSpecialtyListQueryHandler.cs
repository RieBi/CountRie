using Data.Models;

namespace Application.Queries.SpecialtyQueries;
public class GetSpecialtyListQueryHandler(DataContext context) : IRequestHandler<GetSpecialtyListQuery, IList<Specialty>>
{
    private readonly DataContext _context = context;

    public async Task<IList<Specialty>> Handle(GetSpecialtyListQuery request, CancellationToken cancellationToken)
    {
        var specialties = await _context.Specialties
            .ToListAsync(cancellationToken);

        return specialties;
    }
}
