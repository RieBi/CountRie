using Application.Commands.CharacterCommands;
using Application.Commands.CountryCommands;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Converters;
internal class CharacterConverter(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<Character?> TryConvertFromDto(CharacterCreateDto dto, CancellationToken cancellationToken, Character? character = null)
    {
        var country = await _context.Countries
            .Where(f => f.Name == dto.OriginCountryName)
            .SingleOrDefaultAsync(cancellationToken);

        if (country is null)
            return null;

        character ??= new();

        character.Name = dto.Name;
        character.Description = dto.Description;
        character.LongDescription = dto.LongDescription;
        character.BirthDate = dto.BirthDate;
        character.OriginCountry = country;
        character.PortraitUrl = dto.PortraitUrl;
        character.Power = 1;

        return character;
    }
}
