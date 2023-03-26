using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SomtelTechnicalManagmentSystem_STM.Migrations
{
    public partial class addingOcsSupport2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OCSServices",
                table: "OCSServices");

            migrationBuilder.RenameTable(
                name: "OCSServices",
                newName: "OcsServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OcsServices",
                table: "OcsServices",
                column: "id");

            migrationBuilder.CreateTable(
                name: "OcsApiLogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExchangeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcsApiLogs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OcsApiLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OcsServices",
                table: "OcsServices");

            migrationBuilder.RenameTable(
                name: "OcsServices",
                newName: "OCSServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OCSServices",
                table: "OCSServices",
                column: "id");
        }
    }
}
