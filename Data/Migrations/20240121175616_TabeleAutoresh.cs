using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekti.Data.Migrations
{
    public partial class TabeleAutoresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libra_Autore_AutoreId",
                table: "Libra");

            migrationBuilder.AlterColumn<int>(
                name: "AutoreId",
                table: "Libra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Libra_Autore_AutoreId",
                table: "Libra",
                column: "AutoreId",
                principalTable: "Autore",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libra_Autore_AutoreId",
                table: "Libra");

            migrationBuilder.AlterColumn<int>(
                name: "AutoreId",
                table: "Libra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Libra_Autore_AutoreId",
                table: "Libra",
                column: "AutoreId",
                principalTable: "Autore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
