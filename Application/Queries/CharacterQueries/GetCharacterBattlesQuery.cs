using Data.Models;

namespace Application.Queries.CharacterQueries;
public record GetCharacterBattlesQuery(int CharacterId) : IRequest<IList<Battle>>;
