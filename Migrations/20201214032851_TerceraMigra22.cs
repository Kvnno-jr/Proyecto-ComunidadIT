using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class TerceraMigra22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComentarioID",
                table: "PubliViewModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LikeID",
                table: "PubliViewModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublicacionID",
                table: "PubliViewModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RespuestaID",
                table: "PubliViewModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PubliViewModel_ComentarioID",
                table: "PubliViewModel",
                column: "ComentarioID");

            migrationBuilder.CreateIndex(
                name: "IX_PubliViewModel_LikeID",
                table: "PubliViewModel",
                column: "LikeID");

            migrationBuilder.CreateIndex(
                name: "IX_PubliViewModel_PublicacionID",
                table: "PubliViewModel",
                column: "PublicacionID");

            migrationBuilder.CreateIndex(
                name: "IX_PubliViewModel_RespuestaID",
                table: "PubliViewModel",
                column: "RespuestaID");

            migrationBuilder.AddForeignKey(
                name: "FK_PubliViewModel_Comentario_ComentarioID",
                table: "PubliViewModel",
                column: "ComentarioID",
                principalTable: "Comentario",
                principalColumn: "ComentarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PubliViewModel_Like_LikeID",
                table: "PubliViewModel",
                column: "LikeID",
                principalTable: "Like",
                principalColumn: "LikeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PubliViewModel_Publicacion_PublicacionID",
                table: "PubliViewModel",
                column: "PublicacionID",
                principalTable: "Publicacion",
                principalColumn: "PublicacionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PubliViewModel_Respuesta_RespuestaID",
                table: "PubliViewModel",
                column: "RespuestaID",
                principalTable: "Respuesta",
                principalColumn: "RespuestaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PubliViewModel_Comentario_ComentarioID",
                table: "PubliViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PubliViewModel_Like_LikeID",
                table: "PubliViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PubliViewModel_Publicacion_PublicacionID",
                table: "PubliViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PubliViewModel_Respuesta_RespuestaID",
                table: "PubliViewModel");

            migrationBuilder.DropIndex(
                name: "IX_PubliViewModel_ComentarioID",
                table: "PubliViewModel");

            migrationBuilder.DropIndex(
                name: "IX_PubliViewModel_LikeID",
                table: "PubliViewModel");

            migrationBuilder.DropIndex(
                name: "IX_PubliViewModel_PublicacionID",
                table: "PubliViewModel");

            migrationBuilder.DropIndex(
                name: "IX_PubliViewModel_RespuestaID",
                table: "PubliViewModel");

            migrationBuilder.DropColumn(
                name: "ComentarioID",
                table: "PubliViewModel");

            migrationBuilder.DropColumn(
                name: "LikeID",
                table: "PubliViewModel");

            migrationBuilder.DropColumn(
                name: "PublicacionID",
                table: "PubliViewModel");

            migrationBuilder.DropColumn(
                name: "RespuestaID",
                table: "PubliViewModel");
        }
    }
}
