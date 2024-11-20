using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionarioAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubGrupos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    GrupoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGrupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGrupos_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Texto = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    SubGrupoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoResposta = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perguntas_SubGrupos_SubGrupoId",
                        column: x => x.SubGrupoId,
                        principalTable: "SubGrupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcoesResposta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Texto = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PerguntaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcoesResposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcoesResposta_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespostasUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    PerguntaId = table.Column<int>(type: "INTEGER", nullable: false),
                    RespostaTexto = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    OpcaoRespostaId = table.Column<int>(type: "INTEGER", nullable: true),
                    UrlFoto = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: true),
                    DataResposta = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATETIME('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostasUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostasUsuario_OpcoesResposta_OpcaoRespostaId",
                        column: x => x.OpcaoRespostaId,
                        principalTable: "OpcoesResposta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RespostasUsuario_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RespostasUsuario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpcoesResposta_PerguntaId",
                table: "OpcoesResposta",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_SubGrupoId",
                table: "Perguntas",
                column: "SubGrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasUsuario_OpcaoRespostaId",
                table: "RespostasUsuario",
                column: "OpcaoRespostaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasUsuario_PerguntaId",
                table: "RespostasUsuario",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostasUsuario_UsuarioId",
                table: "RespostasUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGrupos_GrupoId",
                table: "SubGrupos",
                column: "GrupoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespostasUsuario");

            migrationBuilder.DropTable(
                name: "OpcoesResposta");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "SubGrupos");

            migrationBuilder.DropTable(
                name: "Grupos");
        }
    }
}
