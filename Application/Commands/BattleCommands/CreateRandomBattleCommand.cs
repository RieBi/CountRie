using Data.Models;

namespace Application.Commands.BattleCommands;
public class CreateRandomBattleCommand(int characterId) : IRequest<Unit>
{
    public int CharacterId { get; set; } = characterId;
}
