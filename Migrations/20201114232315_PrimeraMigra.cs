using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class PrimeraMigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MUsuario",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUsuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MPublicacion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Texto = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPublicacion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MPublicacion_MUsuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "MUsuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MPublicacion_UsuarioID",
                table: "MPublicacion",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MPublicacion");

            migrationBuilder.DropTable(
                name: "MUsuario");
        }
    }
}
