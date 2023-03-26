using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SomtelTechnicalManagmentSystem_STM.Migrations
{
    public partial class addingOcsSupport3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OcsExceptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExchangeNo = table.Column<int>(type: "int", nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcsExceptions", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OcsExceptions");
        }
    }
}
