using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class CuartaMigra2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Publicacion_PublicacionID",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Comentario_ComentarioID",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Publicacion_PublicacionID",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Respuesta_RespuestaID",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_Comentario_ComentarioID",
                table: "Respuesta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Respuesta",
                table: "Respuesta");

            migrationBuilder.DropIndex(
                name: "IX_Respuesta_ComentarioID",
                table: "Respuesta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_ComentarioID",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_PublicacionID",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_RespuestaID",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_PublicacionID",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "LikeID",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "PubComResID",
                table: "Like");

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaID",
                table: "Respuesta",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "PublicacionID",
                table: "Respuesta",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaID",
                table: "Like",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublicacionID",
                table: "Like",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComentarioID",
                table: "Like",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComentarioID",
                table: "Comentario",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Respuesta",
                table: "Respuesta",
                columns: new[] { "RespuestaID", "ComentarioID", "PublicacionID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                columns: new[] { "PublicacionID", "ComentarioID", "RespuestaID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                columns: new[] { "ComentarioID", "PublicacionID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Respuesta",
                table: "Respuesta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "PublicacionID",
                table: "Respuesta");

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaID",
                table: "Respuesta",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaID",
                table: "Like",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ComentarioID",
                table: "Like",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PublicacionID",
                table: "Like",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "LikeID",
                table: "Like",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "PubComResID",
                table: "Like",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComentarioID",
                table: "Comentario",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Respuesta",
                table: "Respuesta",
                column: "RespuestaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "LikeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                column: "ComentarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_ComentarioID",
                table: "Respuesta",
                column: "ComentarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Like_ComentarioID",
                table: "Like",
                column: "ComentarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Like_PublicacionID",
                table: "Like",
                column: "PublicacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Like_RespuestaID",
                table: "Like",
                column: "RespuestaID");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PublicacionID",
                table: "Comentario",
                column: "PublicacionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Publicacion_PublicacionID",
                table: "Comentario",
                column: "PublicacionID",
                principalTable: "Publicacion",
                principalColumn: "PublicacionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Comentario_ComentarioID",
                table: "Like",
                column: "ComentarioID",
                principalTable: "Comentario",
                principalColumn: "ComentarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Publicacion_PublicacionID",
                table: "Like",
                column: "PublicacionID",
                principalTable: "Publicacion",
                principalColumn: "PublicacionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Respuesta_RespuestaID",
                table: "Like",
                column: "RespuestaID",
                principalTable: "Respuesta",
                principalColumn: "RespuestaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Respuesta_Comentario_ComentarioID",
                table: "Respuesta",
                column: "ComentarioID",
                principalTable: "Comentario",
                principalColumn: "ComentarioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
