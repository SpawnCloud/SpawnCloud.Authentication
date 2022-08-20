using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SpawnCloud.Authentication.DataAccess.ServiceBuilder;

public class DataAccessServiceBuilder
{
    public IServiceCollection Services { get; }
    public IConfiguration Configuration { get; }

    public DataAccessServiceBuilder(IServiceCollection services, IConfiguration configuration)
    {
        Services = services;
        Configuration = configuration;
    }
}