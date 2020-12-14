using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class TerceraMigra02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguidor_Usuario_UsuarioID",
                table: "Seguidor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seguidor",
                table: "Seguidor");

            migrationBuilder.DropIndex(
                name: "IX_Seguidor_UsuarioID",
                table: "Seguidor");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Seguidor",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Un_Seguidor",
                table: "Seguidor",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioID1",
                table: "Seguidor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seguidor",
                table: "Seguidor",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidor_UsuarioID1",
                table: "Seguidor",
                column: "UsuarioID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguidor_Usuario_UsuarioID1",
                table: "Seguidor",
                column: "UsuarioID1",
                principalTable: "Usuario",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguidor_Usuario_UsuarioID1",
                table: "Seguidor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seguidor",
                table: "Seguidor");

            migrationBuilder.DropIndex(
                name: "IX_Seguidor_UsuarioID1",
                table: "Seguidor");

            migrationBuilder.DropColumn(
                name: "UsuarioID1",
                table: "Seguidor");

            migrationBuilder.AlterColumn<string>(
                name: "Un_Seguidor",
                table: "Seguidor",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Seguidor",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seguidor",
                table: "Seguidor",
                column: "Un_Seguidor");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidor_UsuarioID",
                table: "Seguidor",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguidor_Usuario_UsuarioID",
                table: "Seguidor",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
