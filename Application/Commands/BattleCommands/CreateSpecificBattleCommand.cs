namespace Application.Commands.BattleCommands;
public record CreateSpecificBattleCommand(int CharacterAId, int CharacterBId) : IRequest<int>;
