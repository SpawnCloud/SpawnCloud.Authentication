using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Validation.AspNetCore;

namespace SpawnCloud.Authentication.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSpawnCloudAuthClient(this IServiceCollection services)
    {
        services.AddOpenIddict()
            .AddValidation(options =>
            {
                // TODO: Allow configuration
                options.SetIssuer("https://localhost:7287");
                
                options.AddEncryptionKey(new SymmetricSecurityKey(
                    Convert.FromBase64String("DRjd/GnduI3Efzen9V9BvbNUfc/VKgXltV7Kbk9sMkY=")));

                options.UseSystemNetHttp();
                
                options.UseAspNetCore();
            });
        services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);

        return services;
    }
}