using Data.Models;

namespace Application.Queries.SpecialtyQueries;
public class GetSpecialtyListQueryHandler(DataContext context) : IRequestHandler<GetSpecialtyListQuery, IList<Specialty>>
{
    private readonly DataContext _context = context;

    public Task<IList<Specialty>> Handle(GetSpecialtyListQuery request, CancellationToken cancellationToken)
    {
        var specialties = _context.Specialties;

        IList<Specialty> specialtyList = [.. specialties];

        return Task.FromResult(specialtyList);
    }
}
