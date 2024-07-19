using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Authorization;
internal class IsOwnerHandler(UserManager<IdentityUser> userManager, DataContext context) : AuthorizationHandler<OperationAuthorizationRequirement, int>
{
    private readonly UserManager<IdentityUser> _userManager = userManager;
    private readonly DataContext _context = context;

    protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, int resource)
    {
        var user = await _userManager.GetUserAsync(context.User);

        if (user is null)
            return;

        var email = await _userManager.GetEmailAsync(user);
        if (email is null)
            return;

        email = email.ToLowerInvariant();

        if (requirement.Name == Requirements.Character.Name)
        {
            var ownerMail = await _context.Characters
                .Where(f => f.Id == resource)
                .Select(f => f.OwnerEmail)
                .SingleOrDefaultAsync();

            if (ownerMail is null)
                return;

            if (ownerMail == email)
                context.Succeed(requirement);
        }
        else if (requirement.Name == Requirements.Country.Name)
        {
            var ownerMail = await _context.Countries
                .Where(f => f.Id == resource)
                .Select(f => f.OwnerEmail)
                .SingleOrDefaultAsync();

            if (ownerMail is null)
                return;

            if (ownerMail == email)
                context.Succeed(requirement);

        }
    }
}
