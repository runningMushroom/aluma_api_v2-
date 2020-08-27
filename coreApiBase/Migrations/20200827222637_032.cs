using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _032 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("10e6a1c4-94f6-4506-9718-54ee9bc94947"));

            migrationBuilder.CreateTable(
                name: "kyc_meta_data",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    IdNumber = table.Column<string>(nullable: true),
                    FirstNames = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    Dob = table.Column<string>(nullable: true),
                    Age = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Citizenship = table.Column<string>(nullable: true),
                    DeceasedStatus = table.Column<string>(nullable: true),
                    CellNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kyc_meta_data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kyc_meta_data_application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("24c7edf4-e28f-47e0-8c47-050e006b888e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9502.lPXPL4whA8Tx2v8Y8kEF3A==.Q+FYWGwANewo7/oaTSZpkiFMd4DK0wJLGxQ5900O5oU=", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_kyc_meta_data_ApplicationId",
                table: "kyc_meta_data",
                column: "ApplicationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kyc_meta_data");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("24c7edf4-e28f-47e0-8c47-050e006b888e"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("10e6a1c4-94f6-4506-9718-54ee9bc94947"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9082.ma0hbylNHdGv8N3wNPwLXQ==.upgPxP6Q2UuXX/imrl5eN/3n0lw0k9XOfChtn9/GkjE=", "Admin" });
        }
    }
}
