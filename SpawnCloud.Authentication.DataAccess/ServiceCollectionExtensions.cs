using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpawnCloud.Authentication.DataAccess.ServiceBuilder;

namespace SpawnCloud.Authentication.DataAccess;

public static class ServiceCollectionExtensions
{
    public static DataAccessServiceBuilder AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        return new DataAccessServiceBuilder(services, configuration);
    }
}