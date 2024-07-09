namespace Application.Queries.CharacterQueries;
public class GetCharacterIdByName(string name) : IRequest<int?>
{
    public string Name { get; set; } = name;
}
