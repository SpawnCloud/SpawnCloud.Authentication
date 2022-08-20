using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpawnCloud.Authentication.DataAccess.Entities;

namespace SpawnCloud.Authentication.DataAccess.Configuration;

public class RoleEntityConfig : IEntityTypeConfiguration<Role>
{
    internal static Guid AdministratorRoleId = new("824E7D2D-9466-41E1-B351-80509D7FE632");
    
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        SeedAdminRole(builder);
    }

    private void SeedAdminRole(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(new Role
        {
            Id = AdministratorRoleId,
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR"
        });
    }
}