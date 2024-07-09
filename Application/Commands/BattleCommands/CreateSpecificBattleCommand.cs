namespace Application.Commands.BattleCommands;
public class CreateSpecificBattleCommand(int characterAId, int characterBId) : IRequest<int>
{
    public int CharacterAId { get; set; } = characterAId;
    public int CharacterBId { get; set; } = characterBId;
}
