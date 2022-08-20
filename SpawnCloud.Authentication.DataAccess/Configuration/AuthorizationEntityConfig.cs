using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpawnCloud.Authentication.DataAccess.Entities;

namespace SpawnCloud.Authentication.DataAccess.Configuration;

public class AuthorizationEntityConfig : IEntityTypeConfiguration<Authorization>
{
    public void Configure(EntityTypeBuilder<Authorization> builder)
    {
        builder.ToTable("Authorizations");
    }
}