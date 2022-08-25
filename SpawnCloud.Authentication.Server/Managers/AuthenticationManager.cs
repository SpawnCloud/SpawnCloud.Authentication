using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using SpawnCloud.Authentication.DataAccess.Entities;
using SpawnCloud.Authentication.Server.Engines;
using SpawnCloud.Authentication.Server.Models;

namespace SpawnCloud.Authentication.Server.Managers;

public class AuthenticationManager : IAuthenticationManager
{
    private readonly UserManager<User> _identityUserManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IClaimsEngine _claimsEngine;
    private readonly IOptionsMonitor<LoginOptions> _loginOptionsMonitor;

    public AuthenticationManager(
        UserManager<User> identityUserManager,
        SignInManager<User> signInManager,
        IClaimsEngine claimsEngine,
        IOptionsMonitor<LoginOptions> loginOptionsMonitor)
    {
        _identityUserManager = identityUserManager;
        _signInManager = signInManager;
        _claimsEngine = claimsEngine;
        _loginOptionsMonitor = loginOptionsMonitor;
    }

    public async Task<AuthenticationResponse> HandlePasswordGrantTypeAsync(OpenIddictRequest request)
    {
        var passwordLoginOptions = _loginOptionsMonitor.CurrentValue.Password;

        // Lookup user based on the configured method.
        var user = passwordLoginOptions.UserLookupMethod switch
        {
            PasswordLoginOptions.LookupMethod.Username => await _identityUserManager.FindByNameAsync(request.Username),
            PasswordLoginOptions.LookupMethod.Email => await _identityUserManager.FindByEmailAsync(request.Username),
            PasswordLoginOptions.LookupMethod.EmailOrUsername => await _identityUserManager.FindByEmailAsync(request.Username) ??
                                                                 await _identityUserManager.FindByNameAsync(request.Username),
            _ => throw new ArgumentOutOfRangeException()
        };
        if (user == null)
        {
            return AuthenticationResponse.Error(OpenIddictConstants.Errors.InvalidGrant,
                Constants.ErrorDescriptions.InvalidCredentials,
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        // Check that the user's password is valid and that the user is allowed to sign in.
        var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, passwordLoginOptions.LockoutOnFailure);
        if (!signInResult.Succeeded)
        {
            var errorDescription = Constants.ErrorDescriptions.InvalidCredentials;
            if (signInResult.IsNotAllowed)
                errorDescription = Constants.ErrorDescriptions.UserSignInNotAllowed;
            else if (signInResult.IsLockedOut)
                errorDescription = Constants.ErrorDescriptions.UserLockedOut;

            return AuthenticationResponse.Error(OpenIddictConstants.Errors.InvalidGrant,
                errorDescription,
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        // Create the claims-based identity that will be used by OpenIddict to generate tokens.
        var identity = await _signInManager.CreateUserPrincipalAsync(user);
        
        identity.SetScopes(GetGrantedScopes(identity, request.GetScopes()));
        identity.SetDestinations(_claimsEngine.GetDestinations);

        return AuthenticationResponse.Success(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }

    public async Task<AuthenticationResponse> HandleRefreshTokenGrantTypeAsync(OpenIddictRequest request, ClaimsPrincipal principal)
    {
        // Retrieve the user profile corresponding to the refresh token.
        var user = await _identityUserManager.FindByIdAsync(principal.GetClaim(OpenIddictConstants.Claims.Subject));
        if (user == null)
        {
            return AuthenticationResponse.Error(OpenIddictConstants.Errors.InvalidGrant,
                Constants.ErrorDescriptions.InvalidRefreshToken,
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        // Ensure the user is still allowed to sign in.
        if (!await _signInManager.CanSignInAsync(user))
        {
            return AuthenticationResponse.Error(OpenIddictConstants.Errors.InvalidGrant,
                Constants.ErrorDescriptions.UserSignInNotAllowed,
                OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }
        
        principal.SetDestinations(_claimsEngine.GetDestinations);
        
        return AuthenticationResponse.Success(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }

    private static IEnumerable<string> GetGrantedScopes(ClaimsPrincipal identity, IEnumerable<string> requestedScopes)
    {
        OpenIddictRequest request;
        // Set the list of scopes granted to the client application.
        // Intersection of scopes from identity, application, and request
        var userAllowedScopes = identity.GetClaims("scope")
            .Select(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .SelectMany(s => s)
            .Concat(new[]
            {
                // Offline access scope is always allowed at the user level
                OpenIddictConstants.Scopes.OfflineAccess,
            })
            .ToArray();

        // Remove the scope claim added by Identity Framework because OpenIddict will maintain it
        identity.RemoveClaims("scope");

        // TODO: Include scopes from application
        var appAllowedScopes = requestedScopes;

        // All scopes allowed by both the app and the user/roles
        var allowedScopes = appAllowedScopes.Intersect(userAllowedScopes).Concat(new[]
        {
            // Scopes that are always allowed
            OpenIddictConstants.Permissions.Scopes.Email,
            OpenIddictConstants.Permissions.Scopes.Profile,
            OpenIddictConstants.Permissions.Scopes.Roles
        });

        return allowedScopes.Intersect(requestedScopes);
    }
}