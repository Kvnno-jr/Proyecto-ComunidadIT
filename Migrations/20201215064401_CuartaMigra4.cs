using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class CuartaMigra4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "PublicacionID",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "ComentarioID",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "RespuestaID",
                table: "Like");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Like",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Like",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                columns: new[] { "PublicacionID", "ComentarioID", "RespuestaID" });
        }
    }
}
