using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _042 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RelatedDataId",
                table: "otp",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "broker_details",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5a3aaf"),
                columns: new[] { "Created", "EmploymentDate", "Modified" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 29, 30, 968, DateTimeKind.Local).AddTicks(7761), new DateTime(2019, 9, 7, 15, 29, 30, 969, DateTimeKind.Local).AddTicks(2852), new DateTime(2020, 9, 7, 15, 29, 30, 968, DateTimeKind.Local).AddTicks(7816) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5c36af"),
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2020, 9, 7, 15, 29, 30, 955, DateTimeKind.Local).AddTicks(4037), new DateTime(2020, 9, 7, 15, 29, 30, 955, DateTimeKind.Local).AddTicks(4626), "9409.T0yzZrmhp2sR6DGevcr1GA==.r5RKE9Q8TbLi3Obc6VOxueBpxG02UnH+x4MgiInHBc8=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatedDataId",
                table: "otp");

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
    }
}
