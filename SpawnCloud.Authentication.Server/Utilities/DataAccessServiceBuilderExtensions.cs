using SpawnCloud.Authentication.DataAccess.PostgreSQL;
using SpawnCloud.Authentication.DataAccess.ServiceBuilder;
using SpawnCloud.Authentication.DataAccess.SQLite;

namespace SpawnCloud.Authentication.Server.Utilities;

public static class DataAccessServiceBuilderExtensions
{
    public static IServiceCollection UseConfiguredDatabaseProvider(this DataAccessServiceBuilder builder)
    {
        var providerName = builder.Configuration["DatabaseProvider"]?.ToUpperInvariant();
        switch (providerName)
        {
            case "SQLITE":
                builder.UseSqlite();
                break;

            case "POSTGRESQL":
                builder.UsePostgreSql();
                break;
            
            default:
                throw new InvalidOperationException("No valid data provider has been set.");
        }

        return builder.Services;
    }
}