using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SpawnCloud.Authentication.DataAccess;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSpawnCloudDataAccess(this IApplicationBuilder builder)
    {
        PerformMigrations(builder.ApplicationServices);
        
        return builder;
    }

    private static void PerformMigrations(IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
        dbContext.Database.Migrate();
    }
}