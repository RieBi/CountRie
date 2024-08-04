using Application.Converters;

namespace Application.Commands.CountryCommands;
internal class EditCountryCommandHandler(DataContext context) : IRequestHandler<EditCountryCommand, Unit>
{
    private readonly DataContext _context = context;

    public async Task<Unit> Handle(EditCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _context.Countries
            .Include(f => f.Specialties)
            .Include(f => f.NaturalResources)
            .Where(f => f.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (country is null)
            return Unit.Value;

        country = await new CountryConverter(_context)
            .TryConvertFromDto(request.CountryCreateDto, cancellationToken, country);

        if (country is null)
            return Unit.Value;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
