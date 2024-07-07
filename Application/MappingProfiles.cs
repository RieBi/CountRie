using Application.Queries.Country;
using Data.Models;

namespace Application;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Country, CountryListDto>();
        CreateMap<Country, CountryDetailsDto>();
    }
}
