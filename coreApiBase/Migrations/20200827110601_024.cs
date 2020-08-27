using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("52134b92-869a-4675-b74c-de9706a0ee33"));

            migrationBuilder.CreateTable(
                name: "FspMandatates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    stepId = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    ClientDetails = table.Column<string>(nullable: true),
                    Products = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    AccNo = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    Address_1 = table.Column<string>(nullable: true),
                    Address_2 = table.Column<string>(nullable: true),
                    Address_3 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FspSignatory = table.Column<string>(nullable: true),
                    AtFsp = table.Column<string>(nullable: true),
                    DateFsp = table.Column<string>(nullable: true),
                    AtClient = table.Column<string>(nullable: true),
                    DateClient = table.Column<string>(nullable: true),
                    FLG = table.Column<string>(nullable: true),
                    FLI = table.Column<string>(nullable: true),
                    FMG = table.Column<string>(nullable: true),
                    FMI = table.Column<string>(nullable: true),
                    FSG = table.Column<string>(nullable: true),
                    FSI = table.Column<string>(nullable: true),
                    FConservative = table.Column<string>(nullable: true),
                    FModeratelyConservative = table.Column<string>(nullable: true),
                    FModerate = table.Column<string>(nullable: true),
                    FModeratelyAggressive = table.Column<string>(nullable: true),
                    FAggressive = table.Column<string>(nullable: true),
                    AttFull = table.Column<string>(nullable: true),
                    DateFUll = table.Column<string>(nullable: true),
                    Adviser = table.Column<string>(nullable: true),
                    Instruction_personal = table.Column<string>(nullable: true),
                    Instruction_advisor = table.Column<string>(nullable: true),
                    Instruction_fsp = table.Column<string>(nullable: true),
                    Payout_1 = table.Column<string>(nullable: true),
                    Payout_2 = table.Column<string>(nullable: true),
                    LLG = table.Column<string>(nullable: true),
                    LLI = table.Column<string>(nullable: true),
                    LMG = table.Column<string>(nullable: true),
                    LMI = table.Column<string>(nullable: true),
                    LSG = table.Column<string>(nullable: true),
                    LSI = table.Column<string>(nullable: true),
                    LConservative = table.Column<string>(nullable: true),
                    LModeratelyConservative = table.Column<string>(nullable: true),
                    LModerate = table.Column<string>(nullable: true),
                    LModeratelyAggressive = table.Column<string>(nullable: true),
                    LAggressive = table.Column<string>(nullable: true),
                    AtLimited = table.Column<string>(nullable: true),
                    DateLimited = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FspMandatates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("0936f253-aedf-4fbd-b2df-3d7def0e79c8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9490.MYckDdjdo6xBB//Xv1sHng==.m7q5jXEqEjdXPCfTU50XRrXqNO8sj0V8I3BtHqlb65I=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FspMandatates");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("0936f253-aedf-4fbd-b2df-3d7def0e79c8"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("52134b92-869a-4675-b74c-de9706a0ee33"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9663.2+EgnLoumYk8WjnZNRUR1A==.l4B82BUDYPAg6selLrvh2B7xa+aprPydKZPYpY0gY8U=", "Admin" });
        }
    }
}
