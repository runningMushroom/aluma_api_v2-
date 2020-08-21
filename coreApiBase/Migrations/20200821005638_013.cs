using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("9a5db3e7-7ec6-4e30-8384-20a20046658e"));

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "application_steps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("b7ce7104-13a9-4161-947b-6e3d865152bb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9901.vthUivFUKeoMmIgTjy7oYw==.vO3nEyTca1JP8BG/mYEnYi8dtPSclUAzULBwolR1Mk8=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("b7ce7104-13a9-4161-947b-6e3d865152bb"));

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "application_steps");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("9a5db3e7-7ec6-4e30-8384-20a20046658e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9728.tMQfqeipRfMuRfBJAZvH4A==.LVPJOhj5+dgWVeRbr6jo5nOTH6CQKMEg7z2D0FMpFGE=", "Admin" });
        }
    }
}
