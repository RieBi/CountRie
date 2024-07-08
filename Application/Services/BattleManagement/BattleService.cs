using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BattleManagement;
public class BattleService : IBattleService
{
    public Battle ExecuteBattle(Character characterA, Character characterB)
    {
        throw new NotImplementedException();
    }

    public Battle ExecuteBattle(Character character)
    {
        throw new NotImplementedException();
    }

    public Character GetRandomOpponent(Character excludedCharacter)
    {
        throw new NotImplementedException();
    }
}
