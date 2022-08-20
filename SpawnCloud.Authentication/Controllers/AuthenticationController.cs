using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using SpawnCloud.Authentication.Managers;
using SpawnCloud.Authentication.Models;

namespace SpawnCloud.Authentication.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationManager _authenticationManager;

    public AuthenticationController(IAuthenticationManager authenticationManager)
    {
        _authenticationManager = authenticationManager;
    }

    [HttpPost("~/connect/token")]
    [IgnoreAntiforgeryToken]
    [Produces("application/json")]
    public async Task<IActionResult> Exchange()
    {
        var request = HttpContext.GetOpenIddictServerRequest() ?? throw new InvalidCastException();
        AuthenticationResponse response;
        if (request.IsPasswordGrantType())
        {
            response = await _authenticationManager.HandlePasswordGrantTypeAsync(request);
        }
        else if (request.IsRefreshTokenGrantType())
        {
            // Retrieve the claims principal stored in the authorization code/device code/refresh token.
            var principal = (await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme)).Principal ??
                            throw new InvalidOperationException();
            
            response = await _authenticationManager.HandleRefreshTokenGrantTypeAsync(request, principal);
        }
        else
        {
            throw new NotImplementedException("The specified grant type is not implemented.");
        }

        if (response.IsSuccess)
        {
            return SignIn(response.ClaimsPrincipal ?? throw new InvalidOperationException(), response.AuthenticationScheme);
        }
        else
        {
            if (response.Properties == null)
                return Forbid(response.AuthenticationScheme);
            
            return Forbid(response.Properties, response.AuthenticationScheme);
        }
    }
    
    
}