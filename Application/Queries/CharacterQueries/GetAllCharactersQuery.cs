using Data.Models;

namespace Application.Queries.CharacterQueries;
public record GetAllCharacterNamesQuery : IRequest<IList<string>>;
