using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class CuartaMigra7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.AlterColumn<int>(
                name: "ComentarioID",
                table: "Comentario",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                columns: new[] { "ComentarioID", "PublicacionID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.AlterColumn<int>(
                name: "ComentarioID",
                table: "Comentario",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                column: "ComentarioID");
        }
    }
}
