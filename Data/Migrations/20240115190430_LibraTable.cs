using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekti.Data.Migrations
{
    public partial class LibraTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAutori",
                table: "Libra");

            migrationBuilder.RenameColumn(
                name: "IdZhanri",
                table: "Libra",
                newName: "ShtepieBotueseId");

            migrationBuilder.RenameColumn(
                name: "IdShtepieBotuese",
                table: "Libra",
                newName: "AutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShtepieBotueseId",
                table: "Libra",
                newName: "IdZhanri");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Libra",
                newName: "IdShtepieBotuese");

            migrationBuilder.AddColumn<string>(
                name: "IdAutori",
                table: "Libra",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
