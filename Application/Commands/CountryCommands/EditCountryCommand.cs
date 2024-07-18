namespace Application.Commands.CountryCommands;
public class EditCountryCommand(int id, CountryCreateDto countryCreateDto) : IRequest<Unit>
{
    public int Id { get; } = id;
    public CountryCreateDto CountryCreateDto { get; } = countryCreateDto;
}
