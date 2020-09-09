using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _038 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("ba65815f-76f3-466e-98d2-6afcf3f0f69d"));

            migrationBuilder.DropColumn(
                name: "InitialsFirstName",
                table: "dividend_tax");

            migrationBuilder.DropColumn(
                name: "TitleSurname",
                table: "dividend_tax");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "dividend_tax",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Initials",
                table: "dividend_tax",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "dividend_tax",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "dividend_tax",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentDate",
                table: "broker_details",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InitialsMatch",
                table: "bank_verification",
                nullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "ProfileImage", "Role", "Signature" },
                values: new object[] { new Guid("3b5df899-3d5c-44fc-9f1f-13c246774967"), new DateTime(2020, 8, 31, 7, 13, 20, 253, DateTimeKind.Local).AddTicks(7318), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(2020, 8, 31, 7, 13, 20, 253, DateTimeKind.Local).AddTicks(7855), "9031.8jqMPPBgMM3uUSIxESiUIg==.y3wp2dhAEiz8XjUl0fW63yoUU7/17c8aWr6JPb6NtOE=", null, "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3b5df899-3d5c-44fc-9f1f-13c246774967"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "dividend_tax");

            migrationBuilder.DropColumn(
                name: "Initials",
                table: "dividend_tax");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "dividend_tax");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "dividend_tax");

            migrationBuilder.DropColumn(
                name: "EmploymentDate",
                table: "broker_details");

            migrationBuilder.DropColumn(
                name: "InitialsMatch",
                table: "bank_verification");

            migrationBuilder.AddColumn<string>(
                name: "InitialsFirstName",
                table: "dividend_tax",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleSurname",
                table: "dividend_tax",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "ProfileImage", "Role", "Signature" },
                values: new object[] { new Guid("ba65815f-76f3-466e-98d2-6afcf3f0f69d"), new DateTime(2020, 8, 29, 1, 37, 5, 194, DateTimeKind.Local).AddTicks(1018), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9765.Av4F4zTT4FpLJJmiG2YM3w==.+lRiPNugBSkTLswjkU6h0WY1G1szAzPovdy0a1rETc8=", null, "Admin", null });
        }
    }
}
