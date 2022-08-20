using Microsoft.EntityFrameworkCore;

namespace SpawnCloud.Authentication.DataAccess.PostgreSQL;

public class PostgreSqlAuthDbContext : AuthDbContext
{
    public PostgreSqlAuthDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DataAccessConstants.SchemaName);
        
        base.OnModelCreating(modelBuilder);
    }
}