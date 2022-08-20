using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpawnCloud.Authentication.DataAccess.Entities;

namespace SpawnCloud.Authentication.DataAccess.Configuration;

public class UserRoleEntityConfig : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");

        SeedAdminRole(builder);
    }

    private void SeedAdminRole(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasData(new UserRole
        {
            UserId = UserEntityConfig.AdminUserId,
            RoleId = RoleEntityConfig.AdministratorRoleId
        });
    }
}