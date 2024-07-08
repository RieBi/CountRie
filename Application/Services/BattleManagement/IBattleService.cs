using Data.Models;

namespace Application.Services.BattleManagement;
public interface IBattleService
{
    Task<Battle> ExecuteBattleAsync(Character character);
    Task<Battle> ExecuteBattleAsync(Character characterA, Character characterB);
    Character GetRandomOpponent(Character excludedCharacter);
}