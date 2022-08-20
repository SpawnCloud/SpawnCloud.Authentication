using OpenIddict.EntityFrameworkCore.Models;

namespace SpawnCloud.Authentication.DataAccess.Entities;

public class Authorization : OpenIddictEntityFrameworkCoreAuthorization<Guid, Application, Token>
{
    
}