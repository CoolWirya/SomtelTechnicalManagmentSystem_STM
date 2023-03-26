using Microsoft.EntityFrameworkCore.Migrations;

namespace SomtelTechnicalManagmentSystem_STM.Migrations
{
    public partial class UpdatingOcsSupport3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FreeUnitId",
                table: "OcsServices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FreeUnitId",
                table: "OcsServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
