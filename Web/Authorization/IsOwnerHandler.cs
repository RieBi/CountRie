using Application.Queries.CharacterQueries;
using Application.Queries.CountryQueries;
using Application.Services.UserManagement;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Application.Authorization;
internal class IsOwnerHandler(IMediator mediator, IUserInfoService userInfoService) : AuthorizationHandler<OperationAuthorizationRequirement, int>
{
    private readonly IMediator _mediator = mediator;
    private readonly IUserInfoService _userInfoService = userInfoService;

    protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, int resource)
    {
        var email = await _userInfoService.GetUserEmailAsync(context.User);
        if (email is null)
            return;

        if (requirement.Name == Requirements.Character.Name)
        {
            var ownerMail = await _mediator.Send(new GetCharacterOwnerEmailQuery(resource));

            if (ownerMail is null)
                return;

            if (ownerMail == email)
                context.Succeed(requirement);
        }
        else if (requirement.Name == Requirements.Country.Name)
        {
            var ownerMail = await _mediator.Send(new GetCountryOwnerEmailQuery(resource));

            if (ownerMail is null)
                return;

            if (ownerMail == email)
                context.Succeed(requirement);
        }
    }
}
