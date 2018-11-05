using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExtendedCore2._0To2._1.Data.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.CreateTable(
                name: "SmAspNetRole",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(256)", nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmAspNetRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmAspNetUser",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(256)", nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(256)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(type: "varchar(256)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmAspNetUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmAspNetRoleClaim",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "varchar(256)", nullable: true),
                    ClaimValue = table.Column<string>(type: "varchar(256)", nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmAspNetRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmAspNetRoleClaim_SmAspNetRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "security",
                        principalTable: "SmAspNetRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmAspNetUserClaim",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "varchar(256)", nullable: true),
                    ClaimValue = table.Column<string>(type: "varchar(256)", nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmAspNetUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmAspNetUserClaim_SmAspNetUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "SmAspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmAspNetUserLogin",
                schema: "security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "varchar(256)", nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmAspNetUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_SmAspNetUserLogin_SmAspNetUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "SmAspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmAspNetUserRole",
                schema: "security",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmAspNetUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_SmAspNetUserRole_SmAspNetRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "security",
                        principalTable: "SmAspNetRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmAspNetUserRole_SmAspNetUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "SmAspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmAspNetUserToken",
                schema: "security",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmAspNetUserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_SmAspNetUserToken_SmAspNetUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "security",
                        principalTable: "SmAspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "security",
                table: "SmAspNetRole",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SmAspNetRoleClaim_RoleId",
                schema: "security",
                table: "SmAspNetRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "security",
                table: "SmAspNetUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "security",
                table: "SmAspNetUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SmAspNetUserClaim_UserId",
                schema: "security",
                table: "SmAspNetUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SmAspNetUserLogin_UserId",
                schema: "security",
                table: "SmAspNetUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SmAspNetUserRole_RoleId",
                schema: "security",
                table: "SmAspNetUserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmAspNetRoleClaim",
                schema: "security");

            migrationBuilder.DropTable(
                name: "SmAspNetUserClaim",
                schema: "security");

            migrationBuilder.DropTable(
                name: "SmAspNetUserLogin",
                schema: "security");

            migrationBuilder.DropTable(
                name: "SmAspNetUserRole",
                schema: "security");

            migrationBuilder.DropTable(
                name: "SmAspNetUserToken",
                schema: "security");

            migrationBuilder.DropTable(
                name: "SmAspNetRole",
                schema: "security");

            migrationBuilder.DropTable(
                name: "SmAspNetUser",
                schema: "security");
        }
    }
}
