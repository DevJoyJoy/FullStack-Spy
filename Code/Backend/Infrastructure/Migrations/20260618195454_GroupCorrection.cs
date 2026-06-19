using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GroupCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_grupo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    link = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_grupo", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    icon = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_lugar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    raio = table.Column<int>(type: "int", nullable: false),
                    grupo_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_lugar", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_lugar_tb_grupo_grupo_id",
                        column: x => x.grupo_id,
                        principalTable: "tb_grupo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notificacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Mensagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdRemetente = table.Column<int>(type: "int", nullable: false),
                    IdDestinatario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacao_tb_usuario_IdDestinatario",
                        column: x => x.IdDestinatario,
                        principalTable: "tb_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificacao_tb_usuario_IdRemetente",
                        column: x => x.IdRemetente,
                        principalTable: "tb_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_localizacao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    latitude = table.Column<double>(type: "double", nullable: false),
                    longitude = table.Column<double>(type: "double", nullable: false),
                    data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_localizacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_localizacao_tb_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "tb_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_usuario_grupo",
                columns: table => new
                {
                    grupo_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario_grupo", x => new { x.grupo_id, x.usuario_id });
                    table.ForeignKey(
                        name: "FK_tb_usuario_grupo_tb_grupo_grupo_id",
                        column: x => x.grupo_id,
                        principalTable: "tb_grupo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_usuario_grupo_tb_usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "tb_usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_IdDestinatario",
                table: "Notificacao",
                column: "IdDestinatario");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacao_IdRemetente",
                table: "Notificacao",
                column: "IdRemetente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_localizacao_usuario_id",
                table: "tb_localizacao",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_lugar_grupo_id",
                table: "tb_lugar",
                column: "grupo_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_grupo_usuario_id",
                table: "tb_usuario_grupo",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificacao");

            migrationBuilder.DropTable(
                name: "tb_localizacao");

            migrationBuilder.DropTable(
                name: "tb_lugar");

            migrationBuilder.DropTable(
                name: "tb_usuario_grupo");

            migrationBuilder.DropTable(
                name: "tb_grupo");

            migrationBuilder.DropTable(
                name: "tb_usuario");
        }
    }
}
