using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _014 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("b7ce7104-13a9-4161-947b-6e3d865152bb"));

            migrationBuilder.AddColumn<string>(
                name: "FactoryStep",
                table: "application_steps",
                nullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("3287b4dd-78b0-443b-bb39-d635670e2751"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9834.v0dXFYNxFuebQzIDrphyQg==.F+DJnT9R2J+TzMm+Fh3hafY3Jas4xqlfX1+ix8tAfkc=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3287b4dd-78b0-443b-bb39-d635670e2751"));

            migrationBuilder.DropColumn(
                name: "FactoryStep",
                table: "application_steps");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("b7ce7104-13a9-4161-947b-6e3d865152bb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9901.vthUivFUKeoMmIgTjy7oYw==.vO3nEyTca1JP8BG/mYEnYi8dtPSclUAzULBwolR1Mk8=", "Admin" });
        }
    }
}
