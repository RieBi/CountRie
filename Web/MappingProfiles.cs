using Application.Queries.CharacterQueries;
using Application.Queries.CountryQueries;
using AutoMapper;
using Data.Models;
using Web.ViewModels;
using Web.ViewModels.Battles;
using Web.ViewModels.Characters;

namespace Web;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Country, ShortInfoViewModel>();
        CreateMap<Character, ShortInfoViewModel>();

        CreateMap<Battle, BattleDetailsViewModel>();
        CreateMap<CharacterDetailsDto, CharacterDetailsViewModel>();

        CreateMap<ShortInfoViewModel, NaturalResource>();
        CreateMap<ShortInfoViewModel, Specialty>();
    }
}
