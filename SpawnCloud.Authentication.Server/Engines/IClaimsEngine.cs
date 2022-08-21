using System.Security.Claims;

namespace SpawnCloud.Authentication.Server.Engines;

public interface IClaimsEngine
{
    IEnumerable<string> GetDestinations(Claim claim);
}