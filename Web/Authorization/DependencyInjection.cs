using Microsoft.AspNetCore.Authorization;

namespace Application.Authorization;
public static class DependencyInjection
{
    public static void AddAuthorizationHandlers(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, IsAdminHandler>();
        services.AddScoped<IAuthorizationHandler, IsOwnerHandler>();
    }
}
