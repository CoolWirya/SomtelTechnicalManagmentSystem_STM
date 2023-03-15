using Microsoft.EntityFrameworkCore.Migrations;

namespace SomtelTechnicalManagmentSystem_STM.Migrations
{
    public partial class intialsetup4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemAlarmID",
                table: "SystemAlarms");

            migrationBuilder.DropColumn(
                name: "ServerAlarmID",
                table: "ServerAlarms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SystemAlarmID",
                table: "SystemAlarms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServerAlarmID",
                table: "ServerAlarms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
