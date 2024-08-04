using Application.Services.BattleManagement;

namespace Application.Commands.BattleCommands;
internal class CreateNamedBattleCommandHandler(IBattleService battleService) : IRequestHandler<CreateNamedBattleCommand, Result<int>>
{
    private readonly IBattleService _battleService = battleService;

    public async Task<Result<int>> Handle(CreateNamedBattleCommand request, CancellationToken cancellationToken)
    {
        var battle = await _battleService.ExecuteBattleAsync(request.CharacterId1, request.CharacterId2, request.BattleName);

        if (battle is null)
            return Result.Fail("Battle could not be created");

        return battle.Id;
    }
}
