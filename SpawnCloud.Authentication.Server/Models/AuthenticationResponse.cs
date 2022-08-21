using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using OpenIddict.Server.AspNetCore;

namespace SpawnCloud.Authentication.Server.Models;

public record AuthenticationResponse
{
    public static AuthenticationResponse Success(ClaimsPrincipal claimsPrincipal, string authenticationScheme)
    {
        return new AuthenticationResponse
        {
            IsSuccess = true,
            AuthenticationScheme = authenticationScheme,
            ClaimsPrincipal = claimsPrincipal
        };
    }

    public static AuthenticationResponse Error(string error, string errorDescription, string authenticationScheme)
    {
        return new AuthenticationResponse
        {
            IsSuccess = false,
            AuthenticationScheme = authenticationScheme,
            Properties = new AuthenticationProperties(new Dictionary<string, string?>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = error,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = errorDescription
            })
        };
    }
    
    public bool IsSuccess { get; init; }
    public string AuthenticationScheme { get; init; } = null!;
    public AuthenticationProperties? Properties { get; init; }
    public ClaimsPrincipal? ClaimsPrincipal { get; init; }

    protected AuthenticationResponse() { }
}