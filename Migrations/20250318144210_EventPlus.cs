using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Plus.Migrations
{
    /// <inheritdoc />
    public partial class EventPlus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    InstituicaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.InstituicaoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoEvento",
                columns: table => new
                {
                    TipoEventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoEvento = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvento", x => x.TipoEventoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    TipoUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TituloTipoUsuario = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.TipoUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventoName = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "DATE", nullable: false),
                    DescricaoEvento = table.Column<string>(type: "TEXT", nullable: false),
                    TipoEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoEventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InstituicaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_Evento_Instituicao_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicao",
                        principalColumn: "InstituicaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evento_TipoEvento_TipoEventoId",
                        column: x => x.TipoEventoId,
                        principalTable: "TipoEvento",
                        principalColumn: "TipoEventoId");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(120)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    TipoUsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TipoUsuario",
                        principalColumn: "TipoUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioEvento",
                columns: table => new
                {
                    ComentarioEventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentarios = table.Column<string>(type: "Text", nullable: false),
                    Exibe = table.Column<bool>(type: "BIT", nullable: false),
                    Evento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Usuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioEvento", x => x.ComentarioEventoId);
                    table.ForeignKey(
                        name: "FK_ComentarioEvento_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "EventoId");
                    table.ForeignKey(
                        name: "FK_ComentarioEvento_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    PresencaEventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Situacao = table.Column<bool>(type: "BIT", nullable: false),
                    UsauarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenca", x => x.PresencaEventoId);
                    table.ForeignKey(
                        name: "FK_Presenca_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presenca_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_EventoId",
                table: "ComentarioEvento",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEvento_UsuarioID",
                table: "ComentarioEvento",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_InstituicaoId",
                table: "Evento",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_TipoEventoId",
                table: "Evento",
                column: "TipoEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicao_CNPJ",
                table: "Instituicao",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_EventoId",
                table: "Presenca",
                column: "EventoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_Situacao",
                table: "Presenca",
                column: "Situacao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_UsuarioId",
                table: "Presenca",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoUsuarioId",
                table: "Usuario",
                column: "TipoUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioEvento");

            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "TipoEvento");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
