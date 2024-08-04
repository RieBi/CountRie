using Application.Services.BattleManagement;

namespace Application.Commands.BattleCommands;
internal class CreateSpecificBattleCommandHandler(IBattleService battleService) : IRequestHandler<CreateSpecificBattleCommand, int>
{
    private readonly IBattleService _battleService = battleService;

    public async Task<int> Handle(CreateSpecificBattleCommand request, CancellationToken cancellationToken)
    {
        if (request.CharacterAId == request.CharacterBId)
            return -1;

        var battle = await _battleService.ExecuteBattleAsync(request.CharacterAId, request.CharacterBId);

        return battle.Id;
    }
}
