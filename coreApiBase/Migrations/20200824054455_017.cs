using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_bank_details",
                table: "bank_details");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("912c3dff-5696-459c-b1d3-f302beebde56"));

            migrationBuilder.RenameTable(
                name: "bank_details",
                newName: "bank_verification");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bank_verification",
                table: "bank_verification",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "risk_profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    StepId = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    Client = table.Column<string>(nullable: true),
                    IdentityNumber = table.Column<string>(nullable: true),
                    Advisor = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<string>(nullable: true),
                    Goal = table.Column<string>(nullable: true),
                    InvestmentTerm = table.Column<string>(nullable: true),
                    RequiredRisk = table.Column<string>(nullable: true),
                    RiskTolerance = table.Column<string>(nullable: true),
                    RiskCapacity = table.Column<string>(nullable: true),
                    Conservative = table.Column<string>(nullable: true),
                    ModeratelyConservative = table.Column<string>(nullable: true),
                    Moderate = table.Column<string>(nullable: true),
                    ModeratelyAggressive = table.Column<string>(nullable: true),
                    Aggressive = table.Column<string>(nullable: true),
                    DerivedProfile = table.Column<string>(nullable: true),
                    AgreeWithOutcome = table.Column<bool>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    advisorNotes = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_risk_profile", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("7d66c8d7-c7e9-4b98-b0cd-15d1759e428e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9227.fOMLCiVzRa+zhMg5ihQvig==.wovklnEe2xhV2u2AuNZVMdIH5bvILI5p/TjcE7xaSyw=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "risk_profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bank_verification",
                table: "bank_verification");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("7d66c8d7-c7e9-4b98-b0cd-15d1759e428e"));

            migrationBuilder.RenameTable(
                name: "bank_verification",
                newName: "bank_details");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bank_details",
                table: "bank_details",
                column: "Id");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("912c3dff-5696-459c-b1d3-f302beebde56"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9891.XtQGurX/Nt8E6bE2daY7mw==.YoB8pd3M8QuRR/gof/ZVhVhXRA3Wcq6UAvvw6BFmy+w=", "Admin" });
        }
    }
}
