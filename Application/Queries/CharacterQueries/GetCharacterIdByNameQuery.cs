namespace Application.Queries.CharacterQueries;
public record GetCharacterIdByNameQuery(string Name) : IRequest<Result<int>>;
