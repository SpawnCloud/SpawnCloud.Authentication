using Microsoft.EntityFrameworkCore;

namespace SpawnCloud.Authentication.DataAccess.SQLite;

public class SqliteAuthDbContext : AuthDbContext
{
    public SqliteAuthDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        string tablePrefix = DataAccessConstants.SchemaName;
        if (!string.IsNullOrWhiteSpace(tablePrefix))
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                string currentTableName = entityType.GetTableName() ?? throw new InvalidOperationException();
                entityType.SetTableName($"{tablePrefix}_{currentTableName}");
            }
        }
    }
}