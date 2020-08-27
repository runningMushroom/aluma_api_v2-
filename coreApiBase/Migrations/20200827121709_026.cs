using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _026 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("1b2ee100-31ce-495c-8112-a942fb3125c1"));

            migrationBuilder.CreateTable(
                name: "Dividends",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StepId = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    NameSurname = table.Column<string>(nullable: true),
                    TradingName = table.Column<string>(nullable: true),
                    AccountReference = table.Column<string>(nullable: true),
                    NatureOfEntity = table.Column<string>(nullable: true),
                    IdNo = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<string>(nullable: true),
                    TaxNo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Postal = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    TitleSurname = table.Column<string>(nullable: true),
                    InitialsFirstName = table.Column<string>(nullable: true),
                    IdNoPassport = table.Column<string>(nullable: true),
                    Work = table.Column<string>(nullable: true),
                    Home = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Exemption_1 = table.Column<string>(nullable: true),
                    Exemption_2 = table.Column<string>(nullable: true),
                    Exemption_3 = table.Column<string>(nullable: true),
                    Exemption_4 = table.Column<string>(nullable: true),
                    Exemption_5 = table.Column<string>(nullable: true),
                    Exemption_6 = table.Column<string>(nullable: true),
                    Exemption_7 = table.Column<string>(nullable: true),
                    Exemption_8 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dividends", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("713762b3-b687-470b-ba8b-98f8558debb6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9645.+uCcmyxLqzixtFoKU+NH2Q==.YU75XgAjCJl39RNGRg84uYIPH3eIoLVk8Byvl573+dM=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dividends");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("713762b3-b687-470b-ba8b-98f8558debb6"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("1b2ee100-31ce-495c-8112-a942fb3125c1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9181.jVdk0bFjiPsu3D9F/lrtyQ==.al2AxLUIrTkE1Sixdlp+qKNcRI6ZK1NALsu1nGnnzE4=", "Admin" });
        }
    }
}
