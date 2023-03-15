using Microsoft.EntityFrameworkCore.Migrations;

namespace SomtelTechnicalManagmentSystem_STM.Migrations
{
    public partial class intialsetup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "SystemAlarms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Logins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemAlarms_TeamId",
                table: "SystemAlarms",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_TeamId",
                table: "Logins",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_Teams_TeamId",
                table: "Logins",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemAlarms_Teams_TeamId",
                table: "SystemAlarms",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_Teams_TeamId",
                table: "Logins");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemAlarms_Teams_TeamId",
                table: "SystemAlarms");

            migrationBuilder.DropIndex(
                name: "IX_SystemAlarms_TeamId",
                table: "SystemAlarms");

            migrationBuilder.DropIndex(
                name: "IX_Logins_TeamId",
                table: "Logins");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "SystemAlarms");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Logins");
        }
    }
}
