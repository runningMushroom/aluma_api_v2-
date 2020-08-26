using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("59c2dac2-89e8-49f0-ac59-f408d4d3eea6"));

            migrationBuilder.DropColumn(
                name: "Aggressive",
                table: "risk_profile");

            migrationBuilder.DropColumn(
                name: "Conservative",
                table: "risk_profile");

            migrationBuilder.DropColumn(
                name: "Moderate",
                table: "risk_profile");

            migrationBuilder.DropColumn(
                name: "ModeratelyAggressive",
                table: "risk_profile");

            migrationBuilder.DropColumn(
                name: "ModeratelyConservative",
                table: "risk_profile");

            migrationBuilder.RenameColumn(
                name: "advisorNotes",
                table: "risk_profile",
                newName: "AdvisorNotes");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("0a879774-5e15-4c43-a48f-3ebe49554eca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9788.GfPEtHbrfW/UBP8lybqdDw==.4IOMyZanvSbV7dABCOC6/XvfQtzxTqXn/nM/VVVQFyU=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("0a879774-5e15-4c43-a48f-3ebe49554eca"));

            migrationBuilder.RenameColumn(
                name: "AdvisorNotes",
                table: "risk_profile",
                newName: "advisorNotes");

            migrationBuilder.AddColumn<string>(
                name: "Aggressive",
                table: "risk_profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Conservative",
                table: "risk_profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Moderate",
                table: "risk_profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModeratelyAggressive",
                table: "risk_profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModeratelyConservative",
                table: "risk_profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("59c2dac2-89e8-49f0-ac59-f408d4d3eea6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9627.w4KQ+piAmzYuM6oA075+Hw==.Kd46aDRUC2lJcRbW/IeIToxAk53bs+WX4QtSrDbbDyc=", "Admin" });
        }
    }
}
