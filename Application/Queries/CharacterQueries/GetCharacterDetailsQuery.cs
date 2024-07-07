namespace Application.Queries.CharacterQueries;
public class GetCharacterDetailsQuery(string name) : IRequest<CharacterDetailsDto?>
{
    public string Name { get; set; } = name;
}
