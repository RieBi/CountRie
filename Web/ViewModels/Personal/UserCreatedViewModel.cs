using Application.Queries.CharacterQueries;
using Application.Queries.CountryQueries;

namespace Web.ViewModels.Personal;

public class UserCreatedViewModel
{
    public required IList<CountryListDto> UserCountries { get; set; } = [];
    public required IList<CharacterListDto> UserCharacters { get; set; } = [];
}
