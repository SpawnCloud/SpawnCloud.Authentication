using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpawnCloud.Authentication.DataAccess.Entities;

namespace SpawnCloud.Authentication.DataAccess.Configuration;

public class UserTokenEntityConfig : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("UserTokens");
    }
}