using Microsoft.EntityFrameworkCore.Migrations;

namespace SomtelTechnicalManagmentSystem_STM.Migrations
{
    public partial class Intialsetup6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentNavbarURL",
                table: "NavbarParent",
                newName: "ParentAspControl");

            migrationBuilder.AddColumn<string>(
                name: "ParentAspAction",
                table: "NavbarParent",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentAspAction",
                table: "NavbarParent");

            migrationBuilder.RenameColumn(
                name: "ParentAspControl",
                table: "NavbarParent",
                newName: "ParentNavbarURL");
        }
    }
}
