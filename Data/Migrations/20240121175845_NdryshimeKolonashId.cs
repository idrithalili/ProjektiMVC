using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekti.Data.Migrations
{
    public partial class NdryshimeKolonashId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libra_ShtepiBotuese_ShtepiBotueseId",
                table: "Libra");

            migrationBuilder.DropForeignKey(
                name: "FK_Libra_Zhanre_ZhanriId",
                table: "Libra");

            migrationBuilder.AlterColumn<int>(
                name: "ZhanriId",
                table: "Libra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ShtepiBotueseId",
                table: "Libra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libra_ShtepiBotuese_ShtepiBotueseId",
                table: "Libra");

            migrationBuilder.DropForeignKey(
                name: "FK_Libra_Zhanre_ZhanriId",
                table: "Libra");

            migrationBuilder.AlterColumn<int>(
                name: "ZhanriId",
                table: "Libra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShtepiBotueseId",
                table: "Libra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
