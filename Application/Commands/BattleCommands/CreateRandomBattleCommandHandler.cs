using Application.Services.BattleManagement;

namespace Application.Commands.BattleCommands;
internal class CreateRandomBattleCommandHandler(IBattleService battleService) : IRequestHandler<CreateRandomBattleCommand, int>
{
    private readonly IBattleService _battleService = battleService;

    public async Task<int> Handle(CreateRandomBattleCommand request, CancellationToken cancellationToken)
    {
        var battle = await _battleService.ExecuteBattleAsync(request.CharacterId);

        return battle.Id;
    }
}
