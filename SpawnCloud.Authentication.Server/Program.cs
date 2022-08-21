using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server;
using SpawnCloud.Authentication.DataAccess;
using SpawnCloud.Authentication.DataAccess.Entities;
using SpawnCloud.Authentication.Server.Engines;
using SpawnCloud.Authentication.Server.Managers;
using SpawnCloud.Authentication.Server.Utilities;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables("SPAWNCLOUD_AUTH_");

builder.Services.AddIdentityCore<User>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 1;
        options.Password.RequiredUniqueChars = 1;

        options.ClaimsIdentity.UserNameClaimType = OpenIddictConstants.Claims.Name;
        options.ClaimsIdentity.RoleClaimType = OpenIddictConstants.Claims.Role;
        options.ClaimsIdentity.UserIdClaimType = OpenIddictConstants.Claims.Subject;
        options.ClaimsIdentity.EmailClaimType = OpenIddictConstants.Claims.Email;
    })
    .AddRoles<Role>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders()
    .AddSignInManager();

builder.Services.Configure<OpenIddictServerOptions>(builder.Configuration.GetSection("AuthServerOptions"));

builder.Services.AddOpenIddict()
    .AddCore(options =>
    {
        options.UseEntityFrameworkCore()
            .UseDbContext<AuthDbContext>()
            .ReplaceDefaultEntities<Application, Authorization, Scope, Token, Guid>();
    })
    .AddServer(options =>
    {
        options.SetTokenEndpointUris("/connect/token");

        options.AllowPasswordFlow();
        options.AllowRefreshTokenFlow();

        // TODO: Require client id
        options.AcceptAnonymousClients();

        // TODO: https://documentation.openiddict.com/configuration/encryption-and-signing-credentials.html#registering-a-certificate-recommended-for-production-ready-scenarios
        options.AddDevelopmentSigningCertificate();
        
        options.AddEncryptionKey(new SymmetricSecurityKey(
            Convert.FromBase64String("DRjd/GnduI3Efzen9V9BvbNUfc/VKgXltV7Kbk9sMkY=")));

        options.UseAspNetCore()
            .EnableTokenEndpointPassthrough();
    })
    .AddValidation(options =>
    {
        options.UseLocalServer();
        
        options.UseAspNetCore();
    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = OpenIddict.Validation.AspNetCore.OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
});

builder.Services.AddDataAccess(builder.Configuration)
    .UseConfiguredDatabaseProvider();

builder.Services.AddControllers();

builder.Services.AddSingleton<IClaimsEngine, ClaimsEngine>();
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();


var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthentication();
app.UseEndpoints(options =>
{
    options.MapControllers();
});

app.UseSpawnCloudDataAccess();
app.Run();