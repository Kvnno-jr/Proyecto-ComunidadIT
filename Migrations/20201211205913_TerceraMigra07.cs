using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class TerceraMigra07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguido");

            migrationBuilder.DropTable(
                name: "Seguidor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguido",
                columns: table => new
                {
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: false),
                    A_Seguir = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioID1 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguido", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Seguido_Usuario_UsuarioID1",
                        column: x => x.UsuarioID1,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seguidor",
                columns: table => new
                {
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: false),
                    Un_Seguidor = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioID1 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguidor", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Seguidor_Usuario_UsuarioID1",
                        column: x => x.UsuarioID1,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguido_UsuarioID1",
                table: "Seguido",
                column: "UsuarioID1");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidor_UsuarioID1",
                table: "Seguidor",
                column: "UsuarioID1");
        }
    }
}
