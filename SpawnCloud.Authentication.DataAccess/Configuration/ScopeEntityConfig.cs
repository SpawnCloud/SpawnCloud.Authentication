using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpawnCloud.Authentication.DataAccess.Entities;

namespace SpawnCloud.Authentication.DataAccess.Configuration;

public class ScopeEntityConfig : IEntityTypeConfiguration<Scope>
{
    public void Configure(EntityTypeBuilder<Scope> builder)
    {
        builder.ToTable("Scopes");
    }
}