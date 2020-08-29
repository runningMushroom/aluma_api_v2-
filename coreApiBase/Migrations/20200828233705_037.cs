using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _037 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("ad683efc-1800-422c-9a6c-53a3baa11df6"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "advisor_advise");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImage",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Signature",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AdvisorId",
                table: "advisor_advise",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "broker_details",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    UnitNo = table.Column<string>(nullable: true),
                    Complex = table.Column<string>(nullable: true),
                    StreetNo = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Supervised = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_broker_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_broker_details_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "ProfileImage", "Role", "Signature" },
                values: new object[] { new Guid("ba65815f-76f3-466e-98d2-6afcf3f0f69d"), new DateTime(2020, 8, 29, 1, 37, 5, 194, DateTimeKind.Local).AddTicks(1018), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9765.Av4F4zTT4FpLJJmiG2YM3w==.+lRiPNugBSkTLswjkU6h0WY1G1szAzPovdy0a1rETc8=", null, "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_broker_details_UserId",
                table: "broker_details",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "broker_details");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("ba65815f-76f3-466e-98d2-6afcf3f0f69d"));

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Signature",
                table: "users");

            migrationBuilder.DropColumn(
                name: "AdvisorId",
                table: "advisor_advise");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "advisor_advise",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("ad683efc-1800-422c-9a6c-53a3baa11df6"), new DateTime(2020, 8, 29, 0, 16, 4, 884, DateTimeKind.Local).AddTicks(6915), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9248.Q4i2h4Xpbzeg2spwy2GzpA==.dBpca0Q+sJvcC+I03vW17GD+QFXdwVhTJCSl6qOy9Og=", "Admin" });
        }
    }
}
