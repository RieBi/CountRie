namespace Application.Queries.CharacterQueries;
internal class GetCharacterListQueryHandler(DataContext context, IMapper mapper) : IRequestHandler<GetCharacterListQuery, IList<CharacterListDto>>
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public Task<IList<CharacterListDto>> Handle(GetCharacterListQuery request, CancellationToken cancellationToken)
    {
        var characters = _context.Characters
            .Include(f => f.OriginCountry);

        var characterDtos = _mapper.Map<IList<CharacterListDto>>(characters);

        return Task.FromResult(characterDtos);
    }
}
