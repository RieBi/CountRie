using Data.Models;

namespace Application.Queries.BattleQueries;
public class GetBattleListQueryHandler(DataContext context) : IRequestHandler<GetBattleListQuery, IList<Battle>>
{
    private readonly DataContext _context = context;

    public async Task<IList<Battle>> Handle(GetBattleListQuery request, CancellationToken cancellationToken)
    {
        IList<Battle> battles = await _context.Battles
            .Include(f => f.WinnerCharacter)
            .Include(f => f.LoserCharacter)
            .Include(f => f.Country)
            .ToListAsync(cancellationToken);

        return battles;
    }
}
