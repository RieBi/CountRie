using System.Security.Claims;

namespace Application.Queries.PersonalQueries;
public class GetUserCreatedEntitiesQuery(ClaimsPrincipal user) : IRequest<UserCreatedDto>
{
    public ClaimsPrincipal User { get; } = user;
}
