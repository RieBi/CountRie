namespace Application.Queries.CharacterQueries;
public class GetCharacterIdByNameQuery(string name) : IRequest<int>
{
    public string Name { get; set; } = name;
}
