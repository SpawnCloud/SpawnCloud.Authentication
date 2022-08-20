using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpawnCloud.Authentication.DataAccess.PostgreSQL.ServiceBuilder;
using SpawnCloud.Authentication.DataAccess.ServiceBuilder;

namespace SpawnCloud.Authentication.DataAccess.PostgreSQL;

public static class DataAccessServiceBuilderExtensions
{
    public static DataAccessPostgreSqlServiceBuilder UsePostgreSql(this DataAccessServiceBuilder builder)
    {
        builder.Services.AddDbContext<AuthDbContext, PostgreSqlAuthDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString(DataAccessConstants.ConnectionStringConfigName);
            options.UseNpgsql(connectionString, optionsBuilder =>
            {
                optionsBuilder.MigrationsAssembly("SpawnCloud.Authentication.DataAccess.PostgreSQL");
                optionsBuilder.MigrationsHistoryTable(DataAccessConstants.MigrationsTableName, DataAccessConstants.SchemaName);
            });
        });

        return new DataAccessPostgreSqlServiceBuilder(builder.Services, builder.Configuration);
    }

    public static DataAccessServiceBuilder UsePostgreSql(this DataAccessServiceBuilder builder, Action<DataAccessPostgreSqlServiceBuilder> configuration)
    {
        configuration(builder.UsePostgreSql());
        return builder;
    }
}