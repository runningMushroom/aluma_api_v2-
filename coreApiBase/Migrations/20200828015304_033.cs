using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _033 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("24c7edf4-e28f-47e0-8c47-050e006b888e"));

            migrationBuilder.AddColumn<int>(
                name: "ChecksCount",
                table: "bank_verification",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "JobID",
                table: "bank_verification",
                nullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("07857fd4-d26a-4f97-bb11-f25dc02ea64e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9222.yvBDgYmw7ZmRxsZjGYUM8Q==.1BC6SqdNl89soO6KMwHwxXGwqWOPhOvvEWfdRJjJfmQ=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("07857fd4-d26a-4f97-bb11-f25dc02ea64e"));

            migrationBuilder.DropColumn(
                name: "ChecksCount",
                table: "bank_verification");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "bank_verification");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("24c7edf4-e28f-47e0-8c47-050e006b888e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9502.lPXPL4whA8Tx2v8Y8kEF3A==.Q+FYWGwANewo7/oaTSZpkiFMd4DK0wJLGxQ5900O5oU=", "Admin" });
        }
    }
}
