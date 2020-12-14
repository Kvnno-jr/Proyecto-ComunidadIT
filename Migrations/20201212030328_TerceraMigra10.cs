using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class TerceraMigra10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguido");

            migrationBuilder.DropTable(
                name: "Seguidor");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguidores");

            migrationBuilder.DropTable(
                name: "Seguidos");

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
    }
}
