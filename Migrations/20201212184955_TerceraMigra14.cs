using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class TerceraMigra14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguidor",
                columns: table => new
                {
                    Un_Seguidor = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguidor", x => new { x.Un_Seguidor, x.UsuarioID });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguido_UsuarioID",
                table: "Seguido",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguido_Usuario_UsuarioID",
                table: "Seguido",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguido_Usuario_UsuarioID",
                table: "Seguido");

            migrationBuilder.DropTable(
                name: "Seguidor");

            migrationBuilder.DropIndex(
                name: "IX_Seguido_UsuarioID",
                table: "Seguido");
        }
    }
}
