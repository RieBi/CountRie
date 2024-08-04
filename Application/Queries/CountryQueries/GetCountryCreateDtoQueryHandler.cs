using Application.Commands.CountryCommands;
using AutoMapper.QueryableExtensions;

namespace Application.Queries.CountryQueries;
internal class GetCountryCreateDtoQueryHandler(DataContext context, IMapper mapper) : IRequestHandler<GetCountryCreateDtoQuery, CountryCreateDto?>
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<CountryCreateDto?> Handle(GetCountryCreateDtoQuery request, CancellationToken cancellationToken)
    {
        var dto = await _context.Countries
            .Where(f => f.Id == request.Id)
            .ProjectTo<CountryCreateDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        return dto;
    }
}
