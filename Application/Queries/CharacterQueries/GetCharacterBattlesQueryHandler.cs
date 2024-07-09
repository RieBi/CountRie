using AutoMapper;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.CharacterQueries;
public class GetCharacterBattlesQueryHandler(DataContext context) : IRequestHandler<GetCharacterBattlesQuery, IList<Battle>>
{
    private readonly DataContext _context = context;

    public Task<IList<Battle>> Handle(GetCharacterBattlesQuery request, CancellationToken cancellationToken)
    {
        var battles = _context.Battles
            .Include(f => f.WinnerCharacter)
            .Include(f => f.LoserCharacter)
            .Include(f => f.Country)
            .Where(f => f.WinnerCharacter.Id == request.CharacterId
            || f.LoserCharacter.Id == request.CharacterId);

        return Task.FromResult((IList<Battle>)[.. battles]);
    }
}
