using Application.Queries.CharacterQueries;
using Application.Queries.CountryQueries;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.PersonalQueries;
public class GetUserCreatedEntitiesQueryHandler(UserManager<IdentityUser> userManager, DataContext context, IMapper mapper) : IRequestHandler<GetUserCreatedEntitiesQuery, UserCreatedDto>
{
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<UserCreatedDto> Handle(GetUserCreatedEntitiesQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserAsync(request.User);
        var dto = new UserCreatedDto();

        if (user is null)
            return dto;

        var email = await _userManager.GetEmailAsync(user);
        if (email is null)
            return dto;

        var userCountries = await _context.Countries
            .Where(f => f.OwnerEmail == email)
            .ProjectTo<CountryListDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var userCharacters = await _context.Characters
            .Where(f => f.OwnerEmail == email)
            .ProjectTo<CharacterListDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        dto.UserCountries = userCountries;
        dto.UserCharacters = userCharacters;

        return dto;
    }
}
