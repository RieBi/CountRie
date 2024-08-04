using Application.Services.BattleManagement;

namespace Application.Commands.BattleCommands;
internal class CreateSpecificBattleCommandHandler(IBattleService battleService) : IRequestHandler<CreateSpecificBattleCommand, Result<int>>
{
    private readonly IBattleService _battleService = battleService;

    public async Task<Result<int>> Handle(CreateSpecificBattleCommand request, CancellationToken cancellationToken)
    {
        if (request.CharacterAId == request.CharacterBId)
            return Result.Fail("A character cannot fight itself.");

        var battle = await _battleService.ExecuteBattleAsync(request.CharacterAId, request.CharacterBId);

        return battle.Id;
    }
}
