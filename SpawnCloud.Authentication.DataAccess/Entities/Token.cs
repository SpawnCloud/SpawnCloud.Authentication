using OpenIddict.EntityFrameworkCore.Models;

namespace SpawnCloud.Authentication.DataAccess.Entities;

public class Token : OpenIddictEntityFrameworkCoreToken<Guid, Application, Authorization>
{
    
}