using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _029 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("db8155bc-9cd8-4e0b-941a-b828209de83a"));

            migrationBuilder.RenameColumn(
                name: "stepId",
                table: "fsp_mandate",
                newName: "StepId");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("96c7c9e2-6a5d-4566-9f00-df2a0f1b5a29"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9174.wR/hB/n098uMjBvpLDEsHw==.MBPMAyXunGLzuiiRov2VOfBRkjoSu3R9x9StSy6VsjU=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("96c7c9e2-6a5d-4566-9f00-df2a0f1b5a29"));

            migrationBuilder.RenameColumn(
                name: "StepId",
                table: "fsp_mandate",
                newName: "stepId");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("db8155bc-9cd8-4e0b-941a-b828209de83a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9229.NUuWalzvDY2g9f+k5iRpkw==.VPsvnW68DR/CSMILnB5sTxmFLOyvKqBJ9s6tu2WkR+Y=", "Admin" });
        }
    }
}
