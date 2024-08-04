using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Application.Authorization;
public static class Requirements
{
    public static OperationAuthorizationRequirement Country { get; } 
        = new() { Name = "Country" };

    public static OperationAuthorizationRequirement Character { get; }
        = new() { Name = "Character" };

}
