using Data.Models;

namespace Application.Services.BattleManagement;
public interface IBattleService
{
    Battle ExecuteBattle(Character character);
    Battle ExecuteBattle(Character characterA, Character characterB);
    Character GetRandomOpponent(Character excludedCharacter);
}