using Microsoft.AspNetCore.Authorization;

namespace Application.Authorization;
public static class DependencyInjection
{
    public static void AddAuthorizationHandlers(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, IsAdminHandler>();
        services.AddScoped<IAuthorizationHandler, IsOwnerHandler>();
    }

    public static void AddExternalAuthorizationProviders(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        var authBuilder = services.AddAuthentication();
        var googleConfigSection = configurationManager.GetSection("Authentication:Google");
        var (googleClientId, googleClientSecret) = (googleConfigSection["ClientId"], googleConfigSection["ClientSecret"]);

        if (googleClientId is not null && googleClientSecret is not null)
        {
            authBuilder.AddGoogle(options =>
            {
                options.ClientId = googleClientId;
                options.ClientSecret = googleClientSecret;
                options.AccessDeniedPath = "/";
            });
        }

        var facebookConfigSection = configurationManager.GetSection("Authentication:Facebook");
        var (facebookClientId, facebookClientSecret) = (facebookConfigSection["ClientId"], facebookConfigSection["ClientSecret"]);

        if (facebookClientId is not null && facebookClientSecret is not null)
        {
            authBuilder.AddFacebook(options =>
            {
                options.ClientId = facebookClientId;
                options.ClientSecret = facebookClientSecret;
                options.AccessDeniedPath = "/";
            });
        }
    }
}
