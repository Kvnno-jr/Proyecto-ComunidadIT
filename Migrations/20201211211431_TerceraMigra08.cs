using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class TerceraMigra08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguido",
                columns: table => new
                {
                    Usuario_Seguido = table.Column<string>(type: "TEXT", nullable: false),
                    Seguido_Por = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguido", x => x.Usuario_Seguido);
                });

            migrationBuilder.CreateTable(
                name: "Seguidor",
                columns: table => new
                {
                    Usuario_Seguidor = table.Column<string>(type: "TEXT", nullable: false),
                    Siguiendo_A = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguidor", x => x.Usuario_Seguidor);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguido");

            migrationBuilder.DropTable(
                name: "Seguidor");
        }
    }
}
