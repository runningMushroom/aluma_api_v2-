using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3287b4dd-78b0-443b-bb39-d635670e2751"));

            migrationBuilder.AddColumn<string>(
                name: "BdaNumber",
                table: "application",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "application_documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    DocuemtnData = table.Column<byte[]>(nullable: true),
                    B64Prefix = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DocumentType = table.Column<int>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_application_documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_application_documents_application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("863b9dd8-6e98-4a5c-a16e-198cc1949c46"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9257.6unCpoiH4RajOOnepvUemQ==.g/2g3cTi9vK1wRQvNqtIwGHDfVaTThtMCEgRFOZkwFU=", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_application_documents_ApplicationId",
                table: "application_documents",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "application_documents");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("863b9dd8-6e98-4a5c-a16e-198cc1949c46"));

            migrationBuilder.DropColumn(
                name: "BdaNumber",
                table: "application");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("3287b4dd-78b0-443b-bb39-d635670e2751"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9834.v0dXFYNxFuebQzIDrphyQg==.F+DJnT9R2J+TzMm+Fh3hafY3Jas4xqlfX1+ix8tAfkc=", "Admin" });
        }
    }
}
