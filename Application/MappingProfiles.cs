using Application.Queries.CharacterQueries;
using Application.Queries.CountryQueries;
using Data.Models;

namespace Application;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Country, CountryListDto>();
        CreateMap<Country, CountryDetailsDto>();

        CreateMap<Character, CharacterListDto>();
        CreateMap<Character, CharacterDetailsDto>();
    }
}
