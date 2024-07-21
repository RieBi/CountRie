namespace Application.Commands.BattleCommands;
public class CreateNamedBattleCommand(int characterId1, int characterId2, string battleName) : IRequest<int>
{
    public int CharacterId1 { get; } = characterId1;
    public int CharacterId2 { get; } = characterId2;
    public string BattleName { get; } = battleName;
}
