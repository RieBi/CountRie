using System.Security.Claims;

namespace Application.Queries.PersonalQueries;
public record GetUserCreatedEntitiesQuery(ClaimsPrincipal User) : IRequest<UserCreatedDto>;
