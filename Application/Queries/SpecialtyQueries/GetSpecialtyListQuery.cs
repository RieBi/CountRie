using Data.Models;

namespace Application.Queries.SpecialtyQueries;
public record GetSpecialtyListQuery : IRequest<IList<Specialty>>;
