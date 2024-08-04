namespace Application.Queries.CountryQueries;
public class GetCountryDetailsQueryHandler(DataContext context, IMapper mapper) : IRequestHandler<GetCountryDetailsQuery, CountryDetailsDto?>
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<CountryDetailsDto?> Handle(GetCountryDetailsQuery request, CancellationToken cancellationToken)
    {
        var country = await _context.Countries
            .Include(f => f.GovernanceType)
            .Include(f => f.Religion)
            .Include(f => f.Language)
            .Include(f => f.Specialties)
            .Include(f => f.NaturalResources)
            .Include(f => f.Characters)
            .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

        if (country is null)
            return null;

        var countryDto = _mapper.Map<CountryDetailsDto>(country);

        return countryDto;
    }
}
