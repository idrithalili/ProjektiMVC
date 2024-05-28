using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekti.Data.Migrations
{
    public partial class TabelaTeReja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autore",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmerAutori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MbiemerAutori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vendbanimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ditelindja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GjendjeLibrash",
                columns: table => new
                {
                    IdLibri = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumerKopjesh = table.Column<int>(type: "int", nullable: false),
                    Gjendje = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GjendjeLibrash", x => x.IdLibri);
                });

            migrationBuilder.CreateTable(
                name: "ShtepiBotuese",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShtepiaBotuese = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vendodhja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShtepiBotuese", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zhanre",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Zhanri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pershkrimi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zhanre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libra",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titulli = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAutori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdZhanri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZhanriId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Viti = table.Column<int>(type: "int", nullable: false),
                    IdShtepieBotuese = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShtepiBotueseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Cmimi = table.Column<int>(type: "int", nullable: false),
                    Pershkrimi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libra_Autore_AutoreId",
                        column: x => x.AutoreId,
                        principalTable: "Autore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libra_ShtepiBotuese_ShtepiBotueseId",
                        column: x => x.ShtepiBotueseId,
                        principalTable: "ShtepiBotuese",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Libra_Zhanre_ZhanriId",
                        column: x => x.ZhanriId,
                        principalTable: "Zhanre",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BotimeLibrash",
                columns: table => new
                {
                    IdBotimi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdLibri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NumerKopjesh = table.Column<int>(type: "int", nullable: false),
                    Viti = table.Column<int>(type: "int", nullable: false),
                    Formati = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotimeLibrash", x => x.IdBotimi);
                    table.ForeignKey(
                        name: "FK_BotimeLibrash_Libra_LibraId",
                        column: x => x.LibraId,
                        principalTable: "Libra",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BotimeLibrash_LibraId",
                table: "BotimeLibrash",
                column: "LibraId");

            migrationBuilder.CreateIndex(
                name: "IX_Libra_AutoreId",
                table: "Libra",
                column: "AutoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Libra_ShtepiBotueseId",
                table: "Libra",
                column: "ShtepiBotueseId");

            migrationBuilder.CreateIndex(
                name: "IX_Libra_ZhanriId",
                table: "Libra",
                column: "ZhanriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotimeLibrash");

            migrationBuilder.DropTable(
                name: "GjendjeLibrash");

            migrationBuilder.DropTable(
                name: "Libra");

            migrationBuilder.DropTable(
                name: "Autore");

            migrationBuilder.DropTable(
                name: "ShtepiBotuese");

            migrationBuilder.DropTable(
                name: "Zhanre");
        }
    }
}
