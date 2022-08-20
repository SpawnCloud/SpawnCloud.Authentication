using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SpawnCloud.Authentication.DataAccess.SQLite.ServiceBuilder;

public class DataAccessSqliteServiceBuilder
{
    public IServiceCollection Services { get; }
    public IConfiguration Configuration { get; }

    public DataAccessSqliteServiceBuilder(IServiceCollection services, IConfiguration configuration)
    {
        Services = services;
        Configuration = configuration;
    }
}