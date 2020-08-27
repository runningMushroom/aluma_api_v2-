using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("0a879774-5e15-4c43-a48f-3ebe49554eca"));

            migrationBuilder.CreateTable(
                name: "record_of_advise",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    StepId = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    BdaNumber = table.Column<string>(nullable: true),
                    AdvisorName = table.Column<string>(nullable: true),
                    AdvisorEmail = table.Column<string>(nullable: true),
                    AdvisorMobile = table.Column<string>(nullable: true),
                    AdviserAddress = table.Column<string>(nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    MaterialInformaiton = table.Column<string>(nullable: true),
                    DerivedProfile = table.Column<string>(nullable: true),
                    Replacement_A = table.Column<string>(nullable: true),
                    Replacement_B = table.Column<string>(nullable: true),
                    Replacement_C = table.Column<string>(nullable: true),
                    Replacement_E = table.Column<string>(nullable: true),
                    ReplacementReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_of_advise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "record_of_advise_items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RecordOfAdviseId = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    RecommendedLumpSum = table.Column<double>(nullable: false),
                    AcceptedLumpSum = table.Column<double>(nullable: false),
                    RecommendedRecurringPremium = table.Column<double>(nullable: false),
                    AcceptedRecurringPremium = table.Column<double>(nullable: false),
                    DeveationReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_of_advise_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_record_of_advise_items_record_of_advise_RecordOfAdviseId",
                        column: x => x.RecordOfAdviseId,
                        principalTable: "record_of_advise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("52134b92-869a-4675-b74c-de9706a0ee33"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9663.2+EgnLoumYk8WjnZNRUR1A==.l4B82BUDYPAg6selLrvh2B7xa+aprPydKZPYpY0gY8U=", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_record_of_advise_items_RecordOfAdviseId",
                table: "record_of_advise_items",
                column: "RecordOfAdviseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "record_of_advise_items");

            migrationBuilder.DropTable(
                name: "record_of_advise");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("52134b92-869a-4675-b74c-de9706a0ee33"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("0a879774-5e15-4c43-a48f-3ebe49554eca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9788.GfPEtHbrfW/UBP8lybqdDw==.4IOMyZanvSbV7dABCOC6/XvfQtzxTqXn/nM/VVVQFyU=", "Admin" });
        }
    }
}
