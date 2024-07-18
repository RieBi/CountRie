using Application.Commands.CountryCommands;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Application.Converters;
internal class CountryConverter(DataContext context, IMapper mapper)
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<Country?> TryConvertFromDto(CountryCreateDto dto, CancellationToken cancellationToken)
    {
        var govType = await _context.GovernanceTypes
            .Where(f => f.Name == dto.GovernanceTypeName)
            .SingleOrDefaultAsync(cancellationToken);

        if (govType is null)
            return null;

        var lang = await _context.Languages
            .Where(f => f.Name == dto.LanguageName)
            .SingleOrDefaultAsync(cancellationToken);

        if (lang is null)
            return null;

        var religion = await _context.Religions
            .Where(f => f.Name == dto.ReligionName)
            .SingleOrDefaultAsync(cancellationToken);

        if (religion is null)
            return null;

        List<NaturalResource?> resources = dto.NaturalResourceNames
            .Select(d => _context.NaturalResources
                .Where(f => f.Name == d)
                .FirstOrDefault())
            .ToList();

        if (resources.Exists(f => f is null))
            return null;

        List<Specialty?> specialties = dto.SpecialtyNames
            .Select(d => _context.Specialties
                .Where(f => f.Name == d)
                .FirstOrDefault())
            .ToList();

        if (specialties.Exists(f => f is null))
            return null;

        var country = _mapper.Map<Country>(dto);
        country.GovernanceType = govType;
        country.Language = lang;
        country.Religion = religion;
        country.NaturalResources = resources!;
        country.Specialties = specialties!;

        return country;
    }
}
