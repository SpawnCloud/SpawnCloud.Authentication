using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpawnCloud.Authentication.DataAccess.PostgreSQL.Migrations
{
    public partial class SeedAdminUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Authentication",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("824e7d2d-9466-41e1-b351-80509d7fe632"), "1a286e04-ca36-4a97-8a10-36f120afb980", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                schema: "Authentication",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("67b91af7-593b-441a-b699-a2a39876cb57"), 0, "1ecf25ec-c204-44da-a631-501a72737d01", "admin@spawncloud.test", true, false, null, "ADMIN@SPAWNCLOUD.TEST", "ADMIN", "AQAAAAEAACcQAAAAEPBjJKZtRAfDDw2Qlx5pt20lq8uhV4ZYd0ZzHWk22IQKvuvbM5xmoYF7akPLGvzYIg==", null, false, "389C1056-3470-4043-8094-BD9E4EFEDB91", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Authentication",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("824e7d2d-9466-41e1-b351-80509d7fe632"), new Guid("67b91af7-593b-441a-b699-a2a39876cb57") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Authentication",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("824e7d2d-9466-41e1-b351-80509d7fe632"), new Guid("67b91af7-593b-441a-b699-a2a39876cb57") });

            migrationBuilder.DeleteData(
                schema: "Authentication",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("824e7d2d-9466-41e1-b351-80509d7fe632"));

            migrationBuilder.DeleteData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("67b91af7-593b-441a-b699-a2a39876cb57"));
        }
    }
}
