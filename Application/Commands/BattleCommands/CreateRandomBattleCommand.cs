namespace Application.Commands.BattleCommands;
public record CreateRandomBattleCommand(int CharacterId) : IRequest<int>;
