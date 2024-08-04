namespace Application.Queries.CountryQueries;
public class GetCountryListQueryHandler(DataContext context, IMapper mapper) : IRequestHandler<GetCountryListQuery, IList<CountryListDto>>
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public Task<IList<CountryListDto>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
    {
        var countries = _context.Countries
            .Include(f => f.GovernanceType)
            .Include(f => f.Religion)
            .Include(f => f.Language);

        var countriesDtos = _mapper.Map<IList<CountryListDto>>(countries);

        return Task.FromResult(countriesDtos);
    }
}
