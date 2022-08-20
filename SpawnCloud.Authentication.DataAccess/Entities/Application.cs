using OpenIddict.EntityFrameworkCore.Models;

namespace SpawnCloud.Authentication.DataAccess.Entities;

public class Application : OpenIddictEntityFrameworkCoreApplication<Guid, Authorization, Token>
{
    
}