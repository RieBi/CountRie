using System.Security.Claims;

namespace Application.Services.UserManagement;
public interface IUserInfoService
{
    Task<string?> GetUserEmailAsync(ClaimsPrincipal user);
}