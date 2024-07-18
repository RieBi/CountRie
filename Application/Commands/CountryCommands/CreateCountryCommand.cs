namespace Application.Commands.CountryCommands;
public class CreateCountryCommand(CountryCreateDto countryCreateDto) : IRequest<int>
{
    public CountryCreateDto CountryCreateDto { get; } = countryCreateDto;
}
