using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("7d66c8d7-c7e9-4b98-b0cd-15d1759e428e"));

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "bank_verification",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "bank_verification",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationType",
                table: "bank_verification",
                nullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("c27352ce-cbc7-4aa2-872c-d6ad3cd73654"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9078.GodWffdadgInVxanb/sMSg==.YQgQsQ+5cFDQgbCIx47/G0JrP6qbnbiwxJ424sTZlPo=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("c27352ce-cbc7-4aa2-872c-d6ad3cd73654"));

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "bank_verification");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "bank_verification");

            migrationBuilder.DropColumn(
                name: "VerificationType",
                table: "bank_verification");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("7d66c8d7-c7e9-4b98-b0cd-15d1759e428e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9227.fOMLCiVzRa+zhMg5ihQvig==.wovklnEe2xhV2u2AuNZVMdIH5bvILI5p/TjcE7xaSyw=", "Admin" });
        }
    }
}
