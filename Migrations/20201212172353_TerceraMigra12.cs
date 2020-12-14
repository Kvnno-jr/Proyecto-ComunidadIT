using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class TerceraMigra12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguidores");

            migrationBuilder.DropTable(
                name: "Seguidos");

            migrationBuilder.CreateTable(
                name: "Seguido",
                columns: table => new
                {
                    A_Seguir = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguido", x => new { x.A_Seguir, x.UsuarioID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguido");

            migrationBuilder.CreateTable(
                name: "Seguidores",
                columns: table => new
                {
                    Seguidor = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguidores", x => x.Seguidor);
                    table.ForeignKey(
                        name: "FK_Seguidores_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seguidos",
                columns: table => new
                {
                    Seguido = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguidos", x => x.Seguido);
                    table.ForeignKey(
                        name: "FK_Seguidos_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguidores_UsuarioID",
                table: "Seguidores",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidos_UsuarioID",
                table: "Seguidos",
                column: "UsuarioID");
        }
    }
}
