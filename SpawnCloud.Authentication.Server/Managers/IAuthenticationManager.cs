using System.Security.Claims;
using OpenIddict.Abstractions;
using SpawnCloud.Authentication.Server.Models;

namespace SpawnCloud.Authentication.Server.Managers;

public interface IAuthenticationManager
{
    Task<AuthenticationResponse> HandlePasswordGrantTypeAsync(OpenIddictRequest request);

    Task<AuthenticationResponse> HandleRefreshTokenGrantTypeAsync(OpenIddictRequest request, ClaimsPrincipal principal);
}