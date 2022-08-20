using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpawnCloud.Authentication.DataAccess.Entities;

namespace SpawnCloud.Authentication.DataAccess.Configuration;

public class UserEntityConfig : IEntityTypeConfiguration<User>
{
    internal static Guid AdminUserId = new("67B91AF7-593B-441A-B699-A2A39876CB57");
    
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        SeedAdminUser(builder);
    }

    private static void SeedAdminUser(EntityTypeBuilder<User> builder)
    {
        var password = new PasswordHasher<User>();
        var adminUser = new User
        {
            Id = AdminUserId,
            Email = "admin@spawncloud.test",
            NormalizedEmail = "ADMIN@SPAWNCLOUD.TEST",
            UserName = "Admin",
            NormalizedUserName = "ADMIN",
            EmailConfirmed = true,
            SecurityStamp = "389C1056-3470-4043-8094-BD9E4EFEDB91"
        };
        adminUser.PasswordHash = password.HashPassword(adminUser, "password");
        builder.HasData(adminUser);
    }
}