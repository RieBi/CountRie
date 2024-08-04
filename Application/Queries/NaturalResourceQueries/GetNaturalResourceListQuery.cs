using Data.Models;

namespace Application.Queries.NaturalResourceQueries;
public record GetNaturalResourceListQuery : IRequest<IList<NaturalResource>>;
