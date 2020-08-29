using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _036 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("9eda248a-4135-4d62-a680-be113bc50b40"));

            migrationBuilder.DropColumn(
                name: "ChecksCount",
                table: "bank_verification");

            migrationBuilder.DropColumn(
                name: "Signed",
                table: "application");

            migrationBuilder.DropColumn(
                name: "SigningRightsGiven",
                table: "application");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "record_of_advise_items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "record_of_advise_items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "primary_schedule_individual_tax_residency_items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "primary_schedule_individual_tax_residency_items",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "primary_schedule_individual_contact_details",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "primary_schedule_individual_contact_details",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "AllowSignature",
                table: "application",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BankValidationComplete",
                table: "application",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DocumentsCreated",
                table: "application",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DocumentsSigned",
                table: "application",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PrimaryFormsComplete",
                table: "application",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SecondaryFormsComplete",
                table: "application",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("ad683efc-1800-422c-9a6c-53a3baa11df6"), new DateTime(2020, 8, 29, 0, 16, 4, 884, DateTimeKind.Local).AddTicks(6915), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9248.Q4i2h4Xpbzeg2spwy2GzpA==.dBpca0Q+sJvcC+I03vW17GD+QFXdwVhTJCSl6qOy9Og=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("ad683efc-1800-422c-9a6c-53a3baa11df6"));

            migrationBuilder.DropColumn(
                name: "Created",
                table: "record_of_advise_items");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "record_of_advise_items");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "primary_schedule_individual_tax_residency_items");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "primary_schedule_individual_tax_residency_items");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "AllowSignature",
                table: "application");

            migrationBuilder.DropColumn(
                name: "BankValidationComplete",
                table: "application");

            migrationBuilder.DropColumn(
                name: "DocumentsCreated",
                table: "application");

            migrationBuilder.DropColumn(
                name: "DocumentsSigned",
                table: "application");

            migrationBuilder.DropColumn(
                name: "PrimaryFormsComplete",
                table: "application");

            migrationBuilder.DropColumn(
                name: "SecondaryFormsComplete",
                table: "application");

            migrationBuilder.AddColumn<int>(
                name: "ChecksCount",
                table: "bank_verification",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Signed",
                table: "application",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SigningRightsGiven",
                table: "application",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("9eda248a-4135-4d62-a680-be113bc50b40"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9717.DR2meck2mc70aVbRwfV/aA==.oC2vCxKuOsGkGkB+7AV1mU5HWxTgSXIhwFZ+EqNkmIs=", "Admin" });
        }
    }
}
