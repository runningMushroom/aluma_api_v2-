using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("e082541f-98f2-4048-be49-220811389a98"));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "users",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("73b8c55e-c6b1-4db8-a80d-87e572e7c429"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9202.JGh779tbaYphUjkfA9DP1A==.iPIjC/lxm6eK5H8R3efNTfb7KFby30g8Cq0/7QRs5h4=", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("73b8c55e-c6b1-4db8-a80d-87e572e7c429"));

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IdNumber", "LastName", "MobileNumber", "MobileVerified", "Modified", "Password", "Role" },
                values: new object[] { new Guid("e082541f-98f2-4048-be49-220811389a98"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "root@aluma.co.za", "rootUser", "9000000000000", "root", "0810000000", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9912.L5U0VnRoBsRvMdVda9CTWQ==.wwfKd7VeIw9PU3mVTmTQjWbY2VG5TCvJjE0gHy4vlWA=", 0 });
        }
    }
}
