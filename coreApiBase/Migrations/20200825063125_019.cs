using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("c27352ce-cbc7-4aa2-872c-d6ad3cd73654"));

            migrationBuilder.DropColumn(
                name: "FaxNumber",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "HomeNumber",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PA_AddressLine_1",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PA_AddressLine_2",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PA_AddressLine_3",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PA_AddressLine_4",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PostalInCare",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PostalSameAsResidentual",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "primary_schedule_individual_contact_details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PA_City",
                table: "primary_schedule_individual_contact_details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PA_Complex",
                table: "primary_schedule_individual_contact_details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PA_StreetName",
                table: "primary_schedule_individual_contact_details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PA_StreetNumber",
                table: "primary_schedule_individual_contact_details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PA_Suburb",
                table: "primary_schedule_individual_contact_details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PA_UnitNumber",
                table: "primary_schedule_individual_contact_details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "primary_schedule_individual_contact_details",
                nullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("65220831-945e-4611-a9f6-0929f936ffa1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9747.EA8C/M1hEycZwaW15tFPbA==.RjMMzjXJLohctB9qaeLSoAuIK05jtw9sRO+si8EZucA=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("65220831-945e-4611-a9f6-0929f936ffa1"));

            migrationBuilder.DropColumn(
                name: "City",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PA_City",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PA_Complex",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PA_StreetName",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PA_StreetNumber",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PA_Suburb",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PA_UnitNumber",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "primary_schedule_individual_contact_details");

            migrationBuilder.AddColumn<string>(
                name: "FaxNumber",
                table: "primary_schedule_individual_contact_details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeNumber",
                table: "primary_schedule_individual_contact_details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PA_AddressLine_1",
                table: "primary_schedule_individual_contact_details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PA_AddressLine_2",
                table: "primary_schedule_individual_contact_details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PA_AddressLine_3",
                table: "primary_schedule_individual_contact_details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PA_AddressLine_4",
                table: "primary_schedule_individual_contact_details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PostalInCare",
                table: "primary_schedule_individual_contact_details",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PostalSameAsResidentual",
                table: "primary_schedule_individual_contact_details",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("c27352ce-cbc7-4aa2-872c-d6ad3cd73654"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9078.GodWffdadgInVxanb/sMSg==.YQgQsQ+5cFDQgbCIx47/G0JrP6qbnbiwxJ424sTZlPo=", "Admin" });
        }
    }
}
