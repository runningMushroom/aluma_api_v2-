using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "advisor_advise",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    StepId = table.Column<Guid>(nullable: false),
                    Introduction = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    MaterialInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advisor_advise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "advisor_advised_products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    AdvisorAdviseId = table.Column<Guid>(nullable: false),
                    Product = table.Column<int>(nullable: false),
                    LumpSum = table.Column<double>(nullable: false),
                    RecurringAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advisor_advised_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_advisor_advised_products_advisor_advise_AdvisorAdviseId",
                        column: x => x.AdvisorAdviseId,
                        principalTable: "advisor_advise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_advisor_advised_products_AdvisorAdviseId",
                table: "advisor_advised_products",
                column: "AdvisorAdviseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "advisor_advised_products");

            migrationBuilder.DropTable(
                name: "advisor_advise");
        }
    }
}
