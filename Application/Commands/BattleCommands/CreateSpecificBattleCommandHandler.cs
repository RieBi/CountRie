
using Application.Services.BattleManagement;

namespace Application.Commands.BattleCommands;
public class CreateSpecificBattleCommandHandler(IBattleService battleService) : IRequestHandler<CreateSpecificBattleCommand, int>
{
    private readonly IBattleService _battleService = battleService;

    public async Task<int> Handle(CreateSpecificBattleCommand request, CancellationToken cancellationToken)
    {
        var battle = await _battleService.ExecuteBattleAsync(request.CharacterAId, request.CharacterBId);

        return battle.Id;
    }
}
