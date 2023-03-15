using Microsoft.EntityFrameworkCore.Migrations;

namespace SomtelTechnicalManagmentSystem_STM.Migrations
{
    public partial class Intialsetup7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OTP",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OTP",
                table: "Logins");
        }
    }
}
