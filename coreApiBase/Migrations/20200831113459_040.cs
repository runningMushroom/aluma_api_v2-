using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _040 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "broker_details",
                columns: new[] { "Id", "City", "Complex", "Country", "Created", "EmploymentDate", "Modified", "PostalCode", "StreetName", "StreetNo", "Suburb", "Supervised", "UnitNo", "UserId" },
                values: new object[] { new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5a3aaf"), "Pretoria", "Cheverney", "South Africa", new DateTime(2020, 8, 31, 13, 34, 59, 243, DateTimeKind.Local).AddTicks(5790), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 31, 13, 34, 59, 243, DateTimeKind.Local).AddTicks(5834), "0184", "Joan", "30", "La Montagne", false, "922", new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5c36af") });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5c36af"),
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2020, 8, 31, 13, 34, 59, 229, DateTimeKind.Local).AddTicks(4043), new DateTime(2020, 8, 31, 13, 34, 59, 229, DateTimeKind.Local).AddTicks(4684), "9365.d3x+Tt31/denHwe+yQZSiw==.+/r0Wf0ZKNFy5falAydJuKTRPV2QgIolT+0XdoRc248=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "broker_details",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5a3aaf"));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5c36af"),
                columns: new[] { "Created", "Modified", "Password" },
                values: new object[] { new DateTime(2020, 8, 31, 9, 35, 34, 648, DateTimeKind.Local).AddTicks(6170), new DateTime(2020, 8, 31, 9, 35, 34, 648, DateTimeKind.Local).AddTicks(6693), "9480.LLZX9IY+fFZksPSOWUkpQA==.ssDn+eiege4tFOkEM5zH21Oy40V76IVRQIDicbqBdtc=" });
        }
    }
}
