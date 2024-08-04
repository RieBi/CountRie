using Data.Models;

namespace Application.Queries.CharacterQueries;
public class GetCharacterBattlesQueryHandler(DataContext context) : IRequestHandler<GetCharacterBattlesQuery, IList<Battle>>
{
    private readonly DataContext _context = context;

    public async Task<IList<Battle>> Handle(GetCharacterBattlesQuery request, CancellationToken cancellationToken)
    {
        IList<Battle> battles = await _context.Battles
            .Include(f => f.WinnerCharacter)
            .Include(f => f.LoserCharacter)
            .Include(f => f.Country)
            .Where(f => f.WinnerCharacter.Id == request.CharacterId
            || f.LoserCharacter.Id == request.CharacterId)
            .ToListAsync(cancellationToken);

        return battles;
    }
}
