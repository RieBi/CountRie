using Application.Services.BattleManagement;

namespace Application.Commands.BattleCommands;
public class CreateRandomBattleCommandHandler(IBattleService battleService) : IRequestHandler<CreateRandomBattleCommand, Unit>
{
    private readonly IBattleService _battleService = battleService;

    public async Task<Unit> Handle(CreateRandomBattleCommand request, CancellationToken cancellationToken)
    {
        await _battleService.ExecuteBattleAsync(request.Character);

        return Unit.Value;
    }
}
