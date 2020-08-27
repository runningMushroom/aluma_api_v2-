using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("a59b2eb7-9aad-4084-962d-40507429c8ad"));

            migrationBuilder.DropColumn(
                name: "NameAndSurname",
                table: "required_secondary_schedules_contacts");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "required_secondary_schedules_contacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "required_secondary_schedules_contacts",
                nullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("10e6a1c4-94f6-4506-9718-54ee9bc94947"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9082.ma0hbylNHdGv8N3wNPwLXQ==.upgPxP6Q2UuXX/imrl5eN/3n0lw0k9XOfChtn9/GkjE=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("10e6a1c4-94f6-4506-9718-54ee9bc94947"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "required_secondary_schedules_contacts");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "required_secondary_schedules_contacts");

            migrationBuilder.AddColumn<string>(
                name: "NameAndSurname",
                table: "required_secondary_schedules_contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("a59b2eb7-9aad-4084-962d-40507429c8ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9442.1sicO0B4EGPQWsiwMlZ5sw==.z4GODqdrMDxudhSuGIT67PhpF2G3qBXHjJv+Qeww2nA=", "Admin" });
        }
    }
}
