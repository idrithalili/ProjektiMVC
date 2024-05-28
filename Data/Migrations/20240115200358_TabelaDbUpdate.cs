using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekti.Data.Migrations
{
    public partial class TabelaDbUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libra_Autore_AutoreId",
                table: "Libra");

            migrationBuilder.DropForeignKey(
                name: "FK_Libra_ShtepiBotuese_ShtepiBotueseId",
                table: "Libra");

            migrationBuilder.DropForeignKey(
                name: "FK_Libra_Zhanre_ZhanriId",
                table: "Libra");


            migrationBuilder.AddForeignKey(
                name: "FK_Libra_Autore_AutoreId",
                table: "Libra",
                column: "AutoreId",
                principalTable: "Autore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libra_ShtepiBotuese_ShtepiBotueseId",
                table: "Libra",
                column: "ShtepiBotueseId",
                principalTable: "ShtepiBotuese",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libra_Zhanre_ZhanriId",
                table: "Libra",
                column: "ZhanriId",
                principalTable: "Zhanre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libra_Autore_AutoreId",
                table: "Libra");

            migrationBuilder.DropForeignKey(
                name: "FK_Libra_ShtepiBotuese_ShtepiBotueseId",
                table: "Libra");

            migrationBuilder.DropForeignKey(
                name: "FK_Libra_Zhanre_ZhanriId",
                table: "Libra");


            migrationBuilder.AddForeignKey(
                name: "FK_Libra_Autore_AutoreId",
                table: "Libra",
                column: "AutoreId",
                principalTable: "Autore",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Libra_ShtepiBotuese_ShtepiBotueseId",
                table: "Libra",
                column: "ShtepiBotueseId",
                principalTable: "ShtepiBotuese",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Libra_Zhanre_ZhanriId",
                table: "Libra",
                column: "ZhanriId",
                principalTable: "Zhanre",
                principalColumn: "Id");
        }
    }
}
