using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class CuartaMigra8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "UsuarioID",
                table: "Like");

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaID",
                table: "Respuesta",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "PublicacionID",
                table: "Like",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComentarioID",
                table: "Like",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RespuestaID",
                table: "Like",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "PublicacionID", "ComentarioID", "RespuestaID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                column: "ComentarioID");
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
                table: "Like");

            migrationBuilder.DropColumn(
                name: "ComentarioID",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "RespuestaID",
                table: "Like");

            migrationBuilder.AlterColumn<int>(
                name: "RespuestaID",
                table: "Respuesta",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioID",
                table: "Like",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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
                column: "UsuarioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                columns: new[] { "ComentarioID", "PublicacionID" });
        }
    }
}
