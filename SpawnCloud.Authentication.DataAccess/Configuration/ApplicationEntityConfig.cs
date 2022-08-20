using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpawnCloud.Authentication.DataAccess.Entities;

namespace SpawnCloud.Authentication.DataAccess.Configuration;

public class ApplicationEntityConfig : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications");
    }
}