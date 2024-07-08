using Data.Models;

namespace Application.Commands.BattleCommands;
public class CreateRandomBattleCommand(int characterId) : IRequest<int>
{
    public int CharacterId { get; set; } = characterId;
}
