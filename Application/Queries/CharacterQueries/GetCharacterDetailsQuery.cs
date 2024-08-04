namespace Application.Queries.CharacterQueries;
public record GetCharacterDetailsQuery(string Name) : IRequest<CharacterDetailsDto?>;
