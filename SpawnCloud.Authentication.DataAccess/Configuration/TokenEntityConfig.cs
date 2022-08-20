using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpawnCloud.Authentication.DataAccess.Entities;

namespace SpawnCloud.Authentication.DataAccess.Configuration;

public class TokenEntityConfig : IEntityTypeConfiguration<Token>
{
    public void Configure(EntityTypeBuilder<Token> builder)
    {
        builder.ToTable("Tokens");
    }
}