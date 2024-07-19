using Application.Converters;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.CountryCommands;
public class CreateCountryCommandHandler(DataContext context, IMapper mapper) : IRequestHandler<CreateCountryCommand, int>
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<int> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await new CountryConverter(_context)
            .TryConvertFromDto(request.CountryCreateDto, cancellationToken);

        if (country is null)
            return -1;

        await _context.Countries.AddAsync(country, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return country.Id;
    }
}
