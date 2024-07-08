using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BattleManagement;
public class BattleService(DataContext context) : IBattleService
{
    private readonly DataContext _context = context;

    public async Task<Battle> ExecuteBattleAsync(Character characterA, Character characterB)
    {
        var totalPower = characterA.Power + characterB.Power;
        var dice = Random.Shared.Next(1, totalPower + 1);

        var winner = dice <= characterA.Power ? characterA : characterB;
        var loser = winner == characterA ? characterB : characterA;

        var country = Random.Shared.Next(2) == 0 ? characterA.OriginCountry : characterB.OriginCountry;

        var battle = new Battle()
        {
            Name = GenerateRandomBattleName(),
            WinnerCharacter = winner,
            LoserCharacter = loser,
            Country = country,
            Date = DateOnly.FromDateTime(DateTime.UtcNow),
        };

        var info = await _context.AddAsync(battle);
        await _context.SaveChangesAsync();
        return info.Entity;
    }

    public Task<Battle> ExecuteBattleAsync(Character character)
    {
        throw new NotImplementedException();
    }

    public Character GetRandomOpponent(Character excludedCharacter)
    {
        throw new NotImplementedException();
    }

    private string GenerateRandomBattleName()
    {
        throw new NotImplementedException();
    }
}
