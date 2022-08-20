using System.Security.Claims;

namespace SpawnCloud.Authentication.Engines;

public interface IClaimsEngine
{
    IEnumerable<string> GetDestinations(Claim claim);
}