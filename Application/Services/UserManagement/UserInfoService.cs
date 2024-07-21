using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Application.Services.UserManagement;
public class UserInfoService(UserManager<IdentityUser> userManager) : IUserInfoService
{
    private readonly UserManager<IdentityUser> _userManager = userManager;

    public async Task<string?> GetUserEmailAsync(ClaimsPrincipal user)
    {
        var userIdentity = await _userManager.GetUserAsync(user);

        if (userIdentity is null)
            return null;

        var email = await _userManager.GetEmailAsync(userIdentity);
        if (email is null)
            return null;

        email = email.ToLowerInvariant();
        return email;
    }
}
