using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekti.Data.Migrations
{
    public partial class KontaktTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontakte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mbiemer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mosha = table.Column<int>(type: "int", nullable: false),
                    Gjinia = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumerTelefoni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesazhi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakte", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kontakte");
        }
    }
}
