using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("96c7c9e2-6a5d-4566-9f00-df2a0f1b5a29"));

            migrationBuilder.DropColumn(
                name: "Payout_1",
                table: "fsp_mandate");

            migrationBuilder.DropColumn(
                name: "Payout_2",
                table: "fsp_mandate");

            migrationBuilder.AddColumn<string>(
                name: "PayoutOption",
                table: "fsp_mandate",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "required_secondary_schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    StepId = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: false),
                    ScheduleType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_required_secondary_schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "required_secondary_schedules_contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    RequiredSecondarySchedulesId = table.Column<Guid>(nullable: false),
                    NameAndSurname = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    IdNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CompletedSchedule = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_required_secondary_schedules_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_required_secondary_schedules_contacts_required_secondary_schedules_RequiredSecondarySchedulesId",
                        column: x => x.RequiredSecondarySchedulesId,
                        principalTable: "required_secondary_schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("a59b2eb7-9aad-4084-962d-40507429c8ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9442.1sicO0B4EGPQWsiwMlZ5sw==.z4GODqdrMDxudhSuGIT67PhpF2G3qBXHjJv+Qeww2nA=", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_required_secondary_schedules_contacts_RequiredSecondarySchedulesId",
                table: "required_secondary_schedules_contacts",
                column: "RequiredSecondarySchedulesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "required_secondary_schedules_contacts");

            migrationBuilder.DropTable(
                name: "required_secondary_schedules");

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("a59b2eb7-9aad-4084-962d-40507429c8ad"));

            migrationBuilder.DropColumn(
                name: "PayoutOption",
                table: "fsp_mandate");

            migrationBuilder.AddColumn<string>(
                name: "Payout_1",
                table: "fsp_mandate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payout_2",
                table: "fsp_mandate",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("96c7c9e2-6a5d-4566-9f00-df2a0f1b5a29"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9174.wR/hB/n098uMjBvpLDEsHw==.MBPMAyXunGLzuiiRov2VOfBRkjoSu3R9x9StSy6VsjU=", "Admin" });
        }
    }
}
