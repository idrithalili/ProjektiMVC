using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekti.Data.Migrations
{
    public partial class NdryshimeLibraTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Libra");

            migrationBuilder.DropColumn(
                name: "ShtepieBotueseId",
                table: "Libra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AutorId",
                table: "Libra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShtepieBotueseId",
                table: "Libra",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
