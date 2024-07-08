using Application.Services.BattleManagement;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.BattleCommands;
public class CreateRandomBattleCommandHandler(IBattleService battleService, DataContext context) : IRequestHandler<CreateRandomBattleCommand, int>
{
    private readonly IBattleService _battleService = battleService;
    private readonly DataContext _context = context;

    public async Task<int> Handle(CreateRandomBattleCommand request, CancellationToken cancellationToken)
    {
        var character = await _context.Characters
            .Include(f => f.OriginCountry)
            .SingleAsync(f => f.Id == request.CharacterId, cancellationToken);

        var battle = await _battleService.ExecuteBattleAsync(character);

        return battle.Id;
    }
}
