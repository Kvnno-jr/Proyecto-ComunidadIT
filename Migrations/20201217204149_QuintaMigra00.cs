using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class QuintaMigra00 : Migration
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

            migrationBuilder.RenameColumn(
                name: "RespuestaID",
                table: "Like",
                newName: "PubComResID");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Like",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Like",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                columns: new[] { "PubComResID", "Tipo", "UsuarioID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Like");

            migrationBuilder.RenameColumn(
                name: "PubComResID",
                table: "Like",
                newName: "RespuestaID");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "Like",
                type: "INTEGER",
                nullable: false,
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                columns: new[] { "PublicacionID", "ComentarioID", "RespuestaID" });
        }
    }
}
