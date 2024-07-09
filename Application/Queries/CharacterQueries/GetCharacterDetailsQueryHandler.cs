using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.CharacterQueries;
public class GetCharacterDetailsQueryHandler(DataContext context, IMapper mapper) : IRequestHandler<GetCharacterDetailsQuery, CharacterDetailsDto?>
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<CharacterDetailsDto?> Handle(GetCharacterDetailsQuery request, CancellationToken cancellationToken)
    {
        var character = await _context.Characters
            .Include(f => f.OriginCountry)
            .FirstOrDefaultAsync(f => f.Name == request.Name, cancellationToken);

        var characterDto = _mapper.Map<CharacterDetailsDto>(character);

        return characterDto;
    }
}
