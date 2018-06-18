using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "amigo",
                columns: table => new
                {
                    AmigoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amigo", x => x.AmigoId);
                });

            migrationBuilder.CreateTable(
                name: "jogo",
                columns: table => new
                {
                    JogoId = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jogo", x => x.JogoId);
                });

            migrationBuilder.CreateTable(
                name: "emprestimo",
                columns: table => new
                {
                    EmprestimoId = table.Column<Guid>(nullable: false),
                    Emprestado = table.Column<byte>(nullable: false),
                    jogoId = table.Column<Guid>(nullable: false),
                    amigoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emprestimo", x => x.EmprestimoId);
                    table.ForeignKey(
                        name: "FK_emprestimo_amigo_amigoId",
                        column: x => x.amigoId,
                        principalTable: "amigo",
                        principalColumn: "AmigoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_emprestimo_jogo_jogoId",
                        column: x => x.jogoId,
                        principalTable: "jogo",
                        principalColumn: "JogoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_emprestimo_amigoId",
                table: "emprestimo",
                column: "amigoId");

            migrationBuilder.CreateIndex(
                name: "IX_emprestimo_jogoId",
                table: "emprestimo",
                column: "jogoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emprestimo");

            migrationBuilder.DropTable(
                name: "amigo");

            migrationBuilder.DropTable(
                name: "jogo");
        }
    }
}
