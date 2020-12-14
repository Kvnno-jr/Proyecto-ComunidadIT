using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class TerceraMigra01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguido_Usuario_UsuarioID1",
                table: "Seguido");

            migrationBuilder.DropForeignKey(
                name: "FK_Seguidor_Usuario_UsuarioID1",
                table: "Seguidor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seguidor",
                table: "Seguidor");

            migrationBuilder.DropIndex(
                name: "IX_Seguidor_UsuarioID1",
                table: "Seguidor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seguido",
                table: "Seguido");

            migrationBuilder.DropIndex(
                name: "IX_Seguido_UsuarioID1",
                table: "Seguido");

            migrationBuilder.DropColumn(
                name: "UsuarioID1",
                table: "Seguidor");

            migrationBuilder.DropColumn(
                name: "UsuarioID1",
                table: "Seguido");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Seguidor",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Un_Seguidor",
                table: "Seguidor",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Seguido",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "A_Seguir",
                table: "Seguido",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioID",
                table: "Like",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seguidor",
                table: "Seguidor",
                column: "Un_Seguidor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seguido",
                table: "Seguido",
                column: "A_Seguir");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidor_UsuarioID",
                table: "Seguidor",
                column: "UsuarioID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Seguidor_Usuario_UsuarioID",
                table: "Seguidor",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguido_Usuario_UsuarioID",
                table: "Seguido");

            migrationBuilder.DropForeignKey(
                name: "FK_Seguidor_Usuario_UsuarioID",
                table: "Seguidor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seguidor",
                table: "Seguidor");

            migrationBuilder.DropIndex(
                name: "IX_Seguidor_UsuarioID",
                table: "Seguidor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seguido",
                table: "Seguido");

            migrationBuilder.DropIndex(
                name: "IX_Seguido_UsuarioID",
                table: "Seguido");

            migrationBuilder.DropColumn(
                name: "Un_Seguidor",
                table: "Seguidor");

            migrationBuilder.DropColumn(
                name: "A_Seguir",
                table: "Seguido");

            migrationBuilder.DropColumn(
                name: "UsuarioID",
                table: "Like");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Seguidor",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioID1",
                table: "Seguidor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Seguido",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioID1",
                table: "Seguido",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seguidor",
                table: "Seguidor",
                column: "UsuarioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seguido",
                table: "Seguido",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidor_UsuarioID1",
                table: "Seguidor",
                column: "UsuarioID1");

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seguidor_Usuario_UsuarioID1",
                table: "Seguidor",
                column: "UsuarioID1",
                principalTable: "Usuario",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
