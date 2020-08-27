using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _027 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FspMandatates",
                table: "FspMandatates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dividends",
                table: "Dividends");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("713762b3-b687-470b-ba8b-98f8558debb6"));

            migrationBuilder.DropColumn(
                name: "Adviser",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "AtLimited",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "AttFull",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "DateFUll",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "DateLimited",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "FAggressive",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "FConservative",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "FLG",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "FLI",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "FMG",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "FMI",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "FModerate",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "FModeratelyAggressive",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "FModeratelyConservative",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "FSG",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "FSI",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "Instruction_advisor",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "Instruction_fsp",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "Instruction_personal",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "LAggressive",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "LConservative",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "LLG",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "LLI",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "LMG",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "LMI",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "LModerate",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "LModeratelyAggressive",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "LModeratelyConservative",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "LSG",
                table: "FspMandatates");

            migrationBuilder.DropColumn(
                name: "LSI",
                table: "FspMandatates");

            migrationBuilder.RenameTable(
                name: "FspMandatates",
                newName: "fsp_mandate");

            migrationBuilder.RenameTable(
                name: "Dividends",
                newName: "dividend_tax");

            migrationBuilder.AddColumn<string>(
                name: "Advisor",
                table: "fsp_mandate",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "fsp_mandate",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InstructionAdvisor",
                table: "fsp_mandate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructionFsp",
                table: "fsp_mandate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructionPersonal",
                table: "fsp_mandate",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "fsp_mandate",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Objective",
                table: "fsp_mandate",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "dividend_tax",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "dividend_tax",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_fsp_mandate",
                table: "fsp_mandate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dividend_tax",
                table: "dividend_tax",
                column: "Id");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("b4004ea2-ba11-41e2-b1a2-2ea3a695e9e7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9668.XdybiqhW2gF88BQbLlvVhg==.J4wypE1hkqehbkOOxJUSPUNvPhHF82gP4cdLfOvqVJ0=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_fsp_mandate",
                table: "fsp_mandate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dividend_tax",
                table: "dividend_tax");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("b4004ea2-ba11-41e2-b1a2-2ea3a695e9e7"));

            migrationBuilder.DropColumn(
                name: "Advisor",
                table: "fsp_mandate");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "fsp_mandate");

            migrationBuilder.DropColumn(
                name: "InstructionAdvisor",
                table: "fsp_mandate");

            migrationBuilder.DropColumn(
                name: "InstructionFsp",
                table: "fsp_mandate");

            migrationBuilder.DropColumn(
                name: "InstructionPersonal",
                table: "fsp_mandate");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "fsp_mandate");

            migrationBuilder.DropColumn(
                name: "Objective",
                table: "fsp_mandate");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "dividend_tax");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "dividend_tax");

            migrationBuilder.RenameTable(
                name: "fsp_mandate",
                newName: "FspMandatates");

            migrationBuilder.RenameTable(
                name: "dividend_tax",
                newName: "Dividends");

            migrationBuilder.AddColumn<string>(
                name: "Adviser",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AtLimited",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttFull",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateFUll",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateLimited",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FAggressive",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FConservative",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FLG",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FLI",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FMG",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FMI",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FModerate",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FModeratelyAggressive",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FModeratelyConservative",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FSG",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FSI",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instruction_advisor",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instruction_fsp",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instruction_personal",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LAggressive",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LConservative",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LLG",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LLI",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LMG",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LMI",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LModerate",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LModeratelyAggressive",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LModeratelyConservative",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LSG",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LSI",
                table: "FspMandatates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FspMandatates",
                table: "FspMandatates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dividends",
                table: "Dividends",
                column: "Id");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("713762b3-b687-470b-ba8b-98f8558debb6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9645.+uCcmyxLqzixtFoKU+NH2Q==.YU75XgAjCJl39RNGRg84uYIPH3eIoLVk8Byvl573+dM=", "Admin" });
        }
    }
}
