using Application.Commands.CharacterCommands;
using AutoMapper.QueryableExtensions;

namespace Application.Queries.CharacterQueries;
internal class GetCharacterCreateDtoQueryHandler(DataContext context, IMapper mapper) : IRequestHandler<GetCharacterCreateDtoQuery, CharacterCreateDto?>
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<CharacterCreateDto?> Handle(GetCharacterCreateDtoQuery request, CancellationToken cancellationToken)
    {
        var dto = await _context.Characters
            .Where(f => f.Id == request.Id)
            .ProjectTo<CharacterCreateDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        return dto;
    }
}
