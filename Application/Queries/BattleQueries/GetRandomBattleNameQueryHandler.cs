using Application.Services.BattleManagement;

namespace Application.Queries.BattleQueries;
internal class GetRandomBattleNameQueryHandler(IBattleService battleService) : IRequestHandler<GetRandomBattleNameQuery, string>
{
    private readonly IBattleService _battleService = battleService;

    public Task<string> Handle(GetRandomBattleNameQuery request, CancellationToken cancellationToken)
    {
        var randomName = _battleService.GenerateRandomBattleName();
        return Task.FromResult(randomName);
    }
}
