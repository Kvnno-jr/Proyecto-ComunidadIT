using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class CuartaMigra9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_Usuario_UsuarioID",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Seguido_Usuario_UsuarioID",
                table: "Seguido");

            migrationBuilder.DropIndex(
                name: "IX_Seguido_UsuarioID",
                table: "Seguido");

            migrationBuilder.DropIndex(
                name: "IX_Publicacion_UsuarioID",
                table: "Publicacion");

            migrationBuilder.DropColumn(
                name: "PublicacionID",
                table: "Respuesta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublicacionID",
                table: "Respuesta",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seguido_UsuarioID",
                table: "Seguido",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_UsuarioID",
                table: "Publicacion",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_Usuario_UsuarioID",
                table: "Publicacion",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seguido_Usuario_UsuarioID",
                table: "Seguido",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
