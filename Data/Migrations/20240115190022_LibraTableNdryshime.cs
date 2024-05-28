using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekti.Data.Migrations
{
    public partial class LibraTableNdryshime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdAutori",
                table: "Libra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdShtepieBotuese",
                table: "Libra",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdZhanri",
                table: "Libra",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAutori",
                table: "Libra");

            migrationBuilder.DropColumn(
                name: "IdShtepieBotuese",
                table: "Libra");

            migrationBuilder.DropColumn(
                name: "IdZhanri",
                table: "Libra");
        }
    }
}
