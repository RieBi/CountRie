using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.BattleQueries;
public class GetBattleListQueryHandler(DataContext context) : IRequestHandler<GetBattleListQuery, IList<Battle>>
{
    private readonly DataContext _context = context;

    public Task<IList<Battle>> Handle(GetBattleListQuery request, CancellationToken cancellationToken)
    {
        var battles = _context.Battles
            .Include(f => f.WinnerCharacter)
            .Include(f => f.LoserCharacter)
            .Include(f => f.Country);

        return Task.FromResult((IList<Battle>)[.. battles]);
    }
}
