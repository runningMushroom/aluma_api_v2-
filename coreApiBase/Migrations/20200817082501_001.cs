using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vueBuilderApi.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "system_users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    IdNumber = table.Column<string>(maxLength: 13, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 11, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    EmailVerified = table.Column<bool>(nullable: false),
                    MobileVerified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_system_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    IdNumber = table.Column<string>(maxLength: 13, nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 11, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    EmailVerified = table.Column<bool>(nullable: false),
                    MobileVerified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_IdNumber",
                table: "users",
                column: "IdNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_MobileNumber",
                table: "users",
                column: "MobileNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "system_users");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
