using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpawnCloud.Authentication.DataAccess.ServiceBuilder;
using SpawnCloud.Authentication.DataAccess.SQLite.ServiceBuilder;

namespace SpawnCloud.Authentication.DataAccess.SQLite;

public static class DataAccessServiceBuilderExtensions
{
    public static DataAccessSqliteServiceBuilder UseSqlite(this DataAccessServiceBuilder builder)
    {
        builder.Services.AddDbContext<AuthDbContext, SqliteAuthDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString(DataAccessConstants.ConnectionStringConfigName);
            options.UseSqlite(connectionString, optionsBuilder =>
            {
                optionsBuilder.MigrationsAssembly("SpawnCloud.Authentication.DataAccess.SQLite");
                optionsBuilder.MigrationsHistoryTable(DataAccessConstants.MigrationsTableName);
            });
        });

        return new DataAccessSqliteServiceBuilder(builder.Services, builder.Configuration);
    }
    
    public static DataAccessServiceBuilder UseSqlite(this DataAccessServiceBuilder builder, Action<DataAccessSqliteServiceBuilder> configuration)
    {
        configuration(builder.UseSqlite());
        return builder;
    }
}