using Microsoft.EntityFrameworkCore.Migrations;

namespace Krofect.Migrations
{
    public partial class TerceraMigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MPublicacion");

            migrationBuilder.DropTable(
                name: "MUsuario");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: false),
                    ImgPerfil = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Publicacion",
                columns: table => new
                {
                    PublicacionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Texto = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacion", x => x.PublicacionID);
                    table.ForeignKey(
                        name: "FK_Publicacion_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seguido",
                columns: table => new
                {
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioID1 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguido", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Seguido_Usuario_UsuarioID1",
                        column: x => x.UsuarioID1,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seguidor",
                columns: table => new
                {
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioID1 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguidor", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Seguidor_Usuario_UsuarioID1",
                        column: x => x.UsuarioID1,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ComentarioID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PublicacionID = table.Column<int>(type: "INTEGER", nullable: false),
                    Texto = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ComentarioID);
                    table.ForeignKey(
                        name: "FK_Comentario_Publicacion_PublicacionID",
                        column: x => x.PublicacionID,
                        principalTable: "Publicacion",
                        principalColumn: "PublicacionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuesta",
                columns: table => new
                {
                    RespuestaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComentarioID = table.Column<int>(type: "INTEGER", nullable: false),
                    Texto = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuesta", x => x.RespuestaID);
                    table.ForeignKey(
                        name: "FK_Respuesta_Comentario_ComentarioID",
                        column: x => x.ComentarioID,
                        principalTable: "Comentario",
                        principalColumn: "ComentarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    PubComResID = table.Column<string>(type: "TEXT", nullable: false),
                    ComentarioID = table.Column<int>(type: "INTEGER", nullable: true),
                    PublicacionID = table.Column<int>(type: "INTEGER", nullable: true),
                    RespuestaID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.PubComResID);
                    table.ForeignKey(
                        name: "FK_Like_Comentario_ComentarioID",
                        column: x => x.ComentarioID,
                        principalTable: "Comentario",
                        principalColumn: "ComentarioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Like_Publicacion_PublicacionID",
                        column: x => x.PublicacionID,
                        principalTable: "Publicacion",
                        principalColumn: "PublicacionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Like_Respuesta_RespuestaID",
                        column: x => x.RespuestaID,
                        principalTable: "Respuesta",
                        principalColumn: "RespuestaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PublicacionID",
                table: "Comentario",
                column: "PublicacionID");

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
                name: "IX_Publicacion_UsuarioID",
                table: "Publicacion",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_ComentarioID",
                table: "Respuesta",
                column: "ComentarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Seguido_UsuarioID1",
                table: "Seguido",
                column: "UsuarioID1");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidor_UsuarioID1",
                table: "Seguidor",
                column: "UsuarioID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Seguido");

            migrationBuilder.DropTable(
                name: "Seguidor");

            migrationBuilder.DropTable(
                name: "Respuesta");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Publicacion");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.CreateTable(
                name: "MUsuario",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Desc = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUsuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MPublicacion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Texto = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPublicacion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MPublicacion_MUsuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "MUsuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MPublicacion_UsuarioID",
                table: "MPublicacion",
                column: "UsuarioID");
        }
    }
}
