using Application.Queries.CharacterQueries;
using Application.Queries.CountryQueries;

namespace Application.Queries.PersonalQueries;
public class UserCreatedDto
{
    public IList<CountryListDto> UserCountries { get; set; } = [];
    public IList<CharacterListDto> UserCharacters { get; set; } = [];
}
