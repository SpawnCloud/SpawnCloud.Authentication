using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Validation.AspNetCore;

namespace SpawnCloud.Authentication.Validation;

public static class HostBuilderExtensions
{
    public static IHostBuilder AddSpawnCloudAuthValidation(this IHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {
            var options = new SpawnCloudAuthOptions();
            var configSection = context.Configuration.GetSection("SpawnCloudAuthValidation");
            configSection.Bind(options);
            services.Configure<SpawnCloudAuthOptions>(configSection);
            
            services.AddOpenIddict()
                .AddValidation(validationBuilder =>
                {
                    validationBuilder.SetIssuer(options.Issuer);

                    if (context.HostingEnvironment.IsDevelopment())
                    {
                        validationBuilder.AddEncryptionKey(new SymmetricSecurityKey(
                            Convert.FromBase64String("DRjd/GnduI3Efzen9V9BvbNUfc/VKgXltV7Kbk9sMkY=")));
                    }
                    else
                    {
                        // TODO: Production environment encryption
                        throw new NotImplementedException();
                    }

                    validationBuilder.UseSystemNetHttp();
                    validationBuilder.UseAspNetCore();
                });
            services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        });

        return builder;
    }
}