using Microsoft.EntityFrameworkCore.Migrations;

namespace SomtelTechnicalManagmentSystem_STM.Migrations
{
    public partial class UpdatingOcsSupport2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FreeUnitName",
                table: "OcsServices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FreeUnitName",
                table: "OcsServices");
        }
    }
}
