using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpawnCloud.Authentication.DataAccess.Entities;

namespace SpawnCloud.Authentication.DataAccess.Configuration;

public class UserClaimEntityConfig : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable("UserClaims");
    }
}