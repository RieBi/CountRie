namespace Application.Queries.CharacterQueries;
public record GetCharacterOwnerEmailQuery(int CharacterId) : IRequest<string?>;
