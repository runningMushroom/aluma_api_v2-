using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _041 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpoymentStatus",
                table: "primary_schedule_individual_client_details");

            migrationBuilder.AddColumn<string>(
                name: "EmploymentStatus",
                table: "primary_schedule_individual_client_details",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "broker_details",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5a3aaf"),
                columns: new[] { "Created", "EmploymentDate", "Modified" },
                values: new object[] { new DateTime(2020, 8, 31, 14, 23, 23, 236, DateTimeKind.Local).AddTicks(7201), new DateTime(2019, 8, 31, 14, 23, 23, 237, DateTimeKind.Local).AddTicks(3488), new DateTime(2020, 8, 31, 14, 23, 23, 236, DateTimeKind.Local).AddTicks(7254) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5c36af"),
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2020, 8, 31, 14, 23, 23, 222, DateTimeKind.Local).AddTicks(9417), new DateTime(2020, 8, 31, 14, 23, 23, 223, DateTimeKind.Local).AddTicks(19), "9683.h+njATijsWlC1gX0TNCGIw==.MOojNNNbTrABTY/Jco9FBvdD3QYnuonfK5T5Lne8/TI=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmploymentStatus",
                table: "primary_schedule_individual_client_details");

            migrationBuilder.AddColumn<string>(
                name: "EmpoymentStatus",
                table: "primary_schedule_individual_client_details",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "broker_details",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5a3aaf"),
                columns: new[] { "Created", "EmploymentDate", "Modified" },
                values: new object[] { new DateTime(2020, 8, 31, 13, 34, 59, 243, DateTimeKind.Local).AddTicks(5790), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 31, 13, 34, 59, 243, DateTimeKind.Local).AddTicks(5834) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5c36af"),
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2020, 8, 31, 13, 34, 59, 229, DateTimeKind.Local).AddTicks(4043), new DateTime(2020, 8, 31, 13, 34, 59, 229, DateTimeKind.Local).AddTicks(4684), "9365.d3x+Tt31/denHwe+yQZSiw==.+/r0Wf0ZKNFy5falAydJuKTRPV2QgIolT+0XdoRc248=" });
        }
    }
}
