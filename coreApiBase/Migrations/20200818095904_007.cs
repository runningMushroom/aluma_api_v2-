using Microsoft.EntityFrameworkCore.Migrations;

namespace alumaApi.Migrations
{
    public partial class _007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_users_UserId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationSteps_Applications_ApplicationId",
                table: "ApplicationSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Otp",
                table: "Otp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationSteps",
                table: "ApplicationSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Otp",
                newName: "otp");

            migrationBuilder.RenameTable(
                name: "ApplicationSteps",
                newName: "application_steps");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "application");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationSteps_ApplicationId",
                table: "application_steps",
                newName: "IX_application_steps_ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_UserId",
                table: "application",
                newName: "IX_application_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_otp",
                table: "otp",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_application_steps",
                table: "application_steps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_application",
                table: "application",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_application_users_UserId",
                table: "application",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_application_steps_application_ApplicationId",
                table: "application_steps",
                column: "ApplicationId",
                principalTable: "application",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_application_users_UserId",
                table: "application");

            migrationBuilder.DropForeignKey(
                name: "FK_application_steps_application_ApplicationId",
                table: "application_steps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_otp",
                table: "otp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_application_steps",
                table: "application_steps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_application",
                table: "application");

            migrationBuilder.RenameTable(
                name: "otp",
                newName: "Otp");

            migrationBuilder.RenameTable(
                name: "application_steps",
                newName: "ApplicationSteps");

            migrationBuilder.RenameTable(
                name: "application",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_application_steps_ApplicationId",
                table: "ApplicationSteps",
                newName: "IX_ApplicationSteps_ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_application_UserId",
                table: "Applications",
                newName: "IX_Applications_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Otp",
                table: "Otp",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationSteps",
                table: "ApplicationSteps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_users_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationSteps_Applications_ApplicationId",
                table: "ApplicationSteps",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
