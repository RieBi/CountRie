namespace Application.Commands.BattleCommands;
public record CreateNamedBattleCommand(int CharacterId1, int CharacterId2, string BattleName) : IRequest<int>;
