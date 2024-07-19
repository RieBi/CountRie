using Application.Commands.CountryCommands;
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

        CreateMap<Country, CountryCreateDto>()
            .ForMember(f => f.GovernanceTypeName,
            options => options.MapFrom(s => s.GovernanceType.Name))
            .ForMember(f => f.LanguageName,
            options => options.MapFrom(s => s.Language.Name))
            .ForMember(f => f.ReligionName,
            options => options.MapFrom(s => s.Religion.Name))
            .ForMember(f => f.NaturalResourceNames,
            options => options.MapFrom(s => s.NaturalResources.Select(r => r.Name)))
            .ForMember(f => f.SpecialtyNames,
            options => options.MapFrom(s => s.Specialties.Select(r => r.Name)))
            ;
    }
}
