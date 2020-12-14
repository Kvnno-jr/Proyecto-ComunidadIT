using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class TerceraMigra06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguido_Usuario_UsuarioID",
                table: "Seguido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seguido",
                table: "Seguido");

            migrationBuilder.DropIndex(
                name: "IX_Seguido_UsuarioID",
                table: "Seguido");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Seguido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "A_Seguir",
                table: "Seguido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioID1",
                table: "Seguido",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seguido",
                table: "Seguido",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Seguido_UsuarioID1",
                table: "Seguido",
                column: "UsuarioID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguido_Usuario_UsuarioID1",
                table: "Seguido",
                column: "UsuarioID1",
                principalTable: "Usuario",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguido_Usuario_UsuarioID1",
                table: "Seguido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seguido",
                table: "Seguido");

            migrationBuilder.DropIndex(
                name: "IX_Seguido_UsuarioID1",
                table: "Seguido");

            migrationBuilder.DropColumn(
                name: "UsuarioID1",
                table: "Seguido");

            migrationBuilder.AlterColumn<string>(
                name: "A_Seguir",
                table: "Seguido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Seguido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seguido",
                table: "Seguido",
                column: "A_Seguir");

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
