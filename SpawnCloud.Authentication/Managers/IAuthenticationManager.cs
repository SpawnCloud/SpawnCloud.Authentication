using System.Security.Claims;
using OpenIddict.Abstractions;
using SpawnCloud.Authentication.Models;

namespace SpawnCloud.Authentication.Managers;

public interface IAuthenticationManager
{
    Task<AuthenticationResponse> HandlePasswordGrantTypeAsync(OpenIddictRequest request);

    Task<AuthenticationResponse> HandleRefreshTokenGrantTypeAsync(OpenIddictRequest request, ClaimsPrincipal principal);
}