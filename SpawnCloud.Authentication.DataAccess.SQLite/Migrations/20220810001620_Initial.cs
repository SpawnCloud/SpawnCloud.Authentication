using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpawnCloud.Authentication.DataAccess.SQLite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authentication_Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ClientSecret = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ConsentType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayNames = table.Column<string>(type: "TEXT", nullable: true),
                    Permissions = table.Column<string>(type: "TEXT", nullable: true),
                    PostLogoutRedirectUris = table.Column<string>(type: "TEXT", nullable: true),
                    Properties = table.Column<string>(type: "TEXT", nullable: true),
                    RedirectUris = table.Column<string>(type: "TEXT", nullable: true),
                    Requirements = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authentication_Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authentication_Scopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcurrencyToken = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Descriptions = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayNames = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Properties = table.Column<string>(type: "TEXT", nullable: true),
                    Resources = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication_Scopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authentication_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authentication_Authorizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Properties = table.Column<string>(type: "TEXT", nullable: true),
                    Scopes = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication_Authorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authentication_Authorizations_Authentication_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Authentication_Applications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Authentication_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authentication_RoleClaims_Authentication_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Authentication_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authentication_UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authentication_UserClaims_Authentication_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Authentication_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authentication_UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Authentication_UserLogins_Authentication_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Authentication_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authentication_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Authentication_UserRoles_Authentication_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Authentication_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authentication_UserRoles_Authentication_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Authentication_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authentication_UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Authentication_UserTokens_Authentication_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Authentication_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Authentication_Tokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AuthorizationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Payload = table.Column<string>(type: "TEXT", nullable: true),
                    Properties = table.Column<string>(type: "TEXT", nullable: true),
                    RedemptionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReferenceId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authentication_Tokens_Authentication_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Authentication_Applications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Authentication_Tokens_Authentication_Authorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "Authentication_Authorizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authentication_Applications_ClientId",
                table: "Authentication_Applications",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authentication_Authorizations_ApplicationId_Status_Subject_Type",
                table: "Authentication_Authorizations",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Authentication_RoleClaims_RoleId",
                table: "Authentication_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Authentication_Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authentication_Scopes_Name",
                table: "Authentication_Scopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authentication_Tokens_ApplicationId_Status_Subject_Type",
                table: "Authentication_Tokens",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Authentication_Tokens_AuthorizationId",
                table: "Authentication_Tokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Authentication_Tokens_ReferenceId",
                table: "Authentication_Tokens",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authentication_UserClaims_UserId",
                table: "Authentication_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Authentication_UserLogins_UserId",
                table: "Authentication_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Authentication_UserRoles_RoleId",
                table: "Authentication_UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Authentication_Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Authentication_Users",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentication_RoleClaims");

            migrationBuilder.DropTable(
                name: "Authentication_Scopes");

            migrationBuilder.DropTable(
                name: "Authentication_Tokens");

            migrationBuilder.DropTable(
                name: "Authentication_UserClaims");

            migrationBuilder.DropTable(
                name: "Authentication_UserLogins");

            migrationBuilder.DropTable(
                name: "Authentication_UserRoles");

            migrationBuilder.DropTable(
                name: "Authentication_UserTokens");

            migrationBuilder.DropTable(
                name: "Authentication_Authorizations");

            migrationBuilder.DropTable(
                name: "Authentication_Roles");

            migrationBuilder.DropTable(
                name: "Authentication_Users");

            migrationBuilder.DropTable(
                name: "Authentication_Applications");
        }
    }
}
