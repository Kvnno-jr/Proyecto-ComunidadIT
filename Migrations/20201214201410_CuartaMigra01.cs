using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class CuartaMigra01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Respuesta",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "PubComResID",
                table: "Like",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "LikeID",
                table: "Like",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Comentario",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "LikeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "LikeID",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Comentario");

            migrationBuilder.AlterColumn<string>(
                name: "PubComResID",
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
                column: "PubComResID");
        }
    }
}
