using Data.Models;

namespace Application.Queries.BattleQueries;
public record GetBattleListQuery : IRequest<IList<Battle>>;
