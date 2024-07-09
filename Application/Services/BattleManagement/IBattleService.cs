using Data.Models;

namespace Application.Services.BattleManagement;
public interface IBattleService
{
    Task<Battle> ExecuteBattleAsync(int characterId);
    Task<Battle> ExecuteBattleAsync(int characterAId, int characterBId);
    Character GetRandomOpponent(int excludedCharacterId);
}