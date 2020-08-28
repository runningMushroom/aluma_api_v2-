using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _0034 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("07857fd4-d26a-4f97-bb11-f25dc02ea64e"));

            migrationBuilder.AddColumn<bool>(
                name: "PaymentConfirmed",
                table: "application",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "advisor_advise",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "application_processor_items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    DocuemntId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Ready = table.Column<bool>(nullable: false),
                    Started = table.Column<bool>(nullable: false),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_processor_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_application_processor_items_application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("99724e6a-1391-4c8a-982e-bfe286828480"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9582.c4/7HeHah5IELx9ULNeSiA==.1ryvDKKkK0kMpTzUm7lne5Z/DQZa6C+Ar2kLbgqGaio=", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_application_processor_items_ApplicationId",
                table: "application_processor_items",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "application_processor_items");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("99724e6a-1391-4c8a-982e-bfe286828480"));

            migrationBuilder.DropColumn(
                name: "PaymentConfirmed",
                table: "application");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "advisor_advise");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("07857fd4-d26a-4f97-bb11-f25dc02ea64e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9222.yvBDgYmw7ZmRxsZjGYUM8Q==.1BC6SqdNl89soO6KMwHwxXGwqWOPhOvvEWfdRJjJfmQ=", "Admin" });
        }
    }
}
