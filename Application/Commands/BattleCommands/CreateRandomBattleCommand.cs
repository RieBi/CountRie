using Data.Models;

namespace Application.Commands.BattleCommands;
public class CreateRandomBattleCommand(Character character) : IRequest<Unit>
{
    public Character Character { get; set; } = character;
}
