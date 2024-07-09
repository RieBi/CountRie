using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.CharacterQueries;
public class GetCharacterBattlesQuery(int characterId) : IRequest<IList<Battle>>
{
    public int CharacterId { get; set; } = characterId;
}
