using Application.Services.BattleManagement;

namespace Application.Commands.BattleCommands;
internal class CreateNamedBattleCommandHandler(IBattleService battleService) : IRequestHandler<CreateNamedBattleCommand, int>
{
    private readonly IBattleService _battleService = battleService;

    public async Task<int> Handle(CreateNamedBattleCommand request, CancellationToken cancellationToken)
    {
        var battle = await _battleService.ExecuteBattleAsync(request.CharacterId1, request.CharacterId2, request.BattleName);

        if (battle is null)
            return -1;

        return battle.Id;
    }
}
