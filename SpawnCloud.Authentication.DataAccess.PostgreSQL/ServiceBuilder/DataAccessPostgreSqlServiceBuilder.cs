using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SpawnCloud.Authentication.DataAccess.PostgreSQL.ServiceBuilder;

public class DataAccessPostgreSqlServiceBuilder
{
    public IServiceCollection Services { get; }
    public IConfiguration Configuration { get; }

    public DataAccessPostgreSqlServiceBuilder(IServiceCollection services, IConfiguration configuration)
    {
        Services = services;
        Configuration = configuration;
    }
}