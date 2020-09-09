using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _039 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3b5df899-3d5c-44fc-9f1f-13c246774967"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "otp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "otp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "ProfileImage", "Role", "Signature" },
                values: new object[] { new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5c36af"), new DateTime(2020, 8, 31, 9, 35, 34, 648, DateTimeKind.Local).AddTicks(6170), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(2020, 8, 31, 9, 35, 34, 648, DateTimeKind.Local).AddTicks(6693), "9480.LLZX9IY+fFZksPSOWUkpQA==.ssDn+eiege4tFOkEM5zH21Oy40V76IVRQIDicbqBdtc=", null, "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3f7cb4b6-3b03-4b28-b012-e602ec5c36af"));

            migrationBuilder.DropColumn(
                name: "Created",
                table: "otp");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "otp");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "ProfileImage", "Role", "Signature" },
                values: new object[] { new Guid("3b5df899-3d5c-44fc-9f1f-13c246774967"), new DateTime(2020, 8, 31, 7, 13, 20, 253, DateTimeKind.Local).AddTicks(7318), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(2020, 8, 31, 7, 13, 20, 253, DateTimeKind.Local).AddTicks(7855), "9031.8jqMPPBgMM3uUSIxESiUIg==.y3wp2dhAEiz8XjUl0fW63yoUU7/17c8aWr6JPb6NtOE=", null, "Admin", null });
        }
    }
}
