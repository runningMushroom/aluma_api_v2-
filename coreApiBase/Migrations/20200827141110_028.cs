using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _028 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("b4004ea2-ba11-41e2-b1a2-2ea3a695e9e7"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("db8155bc-9cd8-4e0b-941a-b828209de83a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9229.NUuWalzvDY2g9f+k5iRpkw==.VPsvnW68DR/CSMILnB5sTxmFLOyvKqBJ9s6tu2WkR+Y=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("db8155bc-9cd8-4e0b-941a-b828209de83a"));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("b4004ea2-ba11-41e2-b1a2-2ea3a695e9e7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9668.XdybiqhW2gF88BQbLlvVhg==.J4wypE1hkqehbkOOxJUSPUNvPhHF82gP4cdLfOvqVJ0=", "Admin" });
        }
    }
}
