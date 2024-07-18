using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.CountryCommands;
public class CreateCountryCommandHandler(DataContext context, IMapper mapper) : IRequestHandler<CreateCountryCommand, int>
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<int> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var dto = request.CountryCreateDto;

        var govType = await _context.GovernanceTypes
            .Where(f => f.Name == dto.GovernanceTypeName)
            .SingleOrDefaultAsync(cancellationToken);

        if (govType is null)
            return -1;

        var lang = await _context.Languages
            .Where(f => f.Name == dto.LanguageName)
            .SingleOrDefaultAsync(cancellationToken);

        if (lang is null)
            return -1;

        var religion = await _context.Religions
            .Where(f => f.Name == dto.ReligionName)
            .SingleOrDefaultAsync(cancellationToken);

        if (religion is null)
            return -1;

        List<NaturalResource?> resources = dto.NaturalResourceNames
            .Select(d => _context.NaturalResources
                .Where(f => f.Name == d)
                .FirstOrDefault())
            .ToList();

        if (resources.Exists(f => f is null))
            return -1;

        List<Specialty?> specialties = dto.SpecialtyNames
            .Select(d => _context.Specialties
                .Where(f => f.Name == d)
                .FirstOrDefault())
            .ToList();

        if (specialties.Exists(f => f is null))
            return -1;

        var country = _mapper.Map<Country>(dto);
        country.GovernanceType = govType;
        country.Language = lang;
        country.Religion = religion;
        country.NaturalResources = resources!;
        country.Specialties = specialties!;

        await _context.AddAsync(country, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return country.Id;
    }
}
