using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpawnCloud.Authentication.DataAccess.SQLite.Migrations
{
    public partial class SeedAdminUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authentication_Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("824e7d2d-9466-41e1-b351-80509d7fe632"), "fc2469b1-6687-4724-ad86-fb270ad062d7", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Authentication_Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("67b91af7-593b-441a-b699-a2a39876cb57"), 0, "ea87d0dd-abe8-4a55-8d62-6a84fcdd09bb", "admin@spawncloud.test", true, false, null, "ADMIN@SPAWNCLOUD.TEST", "ADMIN", "AQAAAAEAACcQAAAAEJqvAkTuoTQ79F++Vv8PC5zcv3PB7JkLJ04XQkVAkvJ3TOEJDA3EfVkmmC3VPd1vMA==", null, false, "389C1056-3470-4043-8094-BD9E4EFEDB91", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Authentication_UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("824e7d2d-9466-41e1-b351-80509d7fe632"), new Guid("67b91af7-593b-441a-b699-a2a39876cb57") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authentication_UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("824e7d2d-9466-41e1-b351-80509d7fe632"), new Guid("67b91af7-593b-441a-b699-a2a39876cb57") });

            migrationBuilder.DeleteData(
                table: "Authentication_Roles",
                keyColumn: "Id",
                keyValue: new Guid("824e7d2d-9466-41e1-b351-80509d7fe632"));

            migrationBuilder.DeleteData(
                table: "Authentication_Users",
                keyColumn: "Id",
                keyValue: new Guid("67b91af7-593b-441a-b699-a2a39876cb57"));
        }
    }
}
