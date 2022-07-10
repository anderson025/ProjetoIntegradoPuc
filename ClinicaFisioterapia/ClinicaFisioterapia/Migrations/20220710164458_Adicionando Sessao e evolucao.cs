using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ClinicaFisioterapia.Migrations
{
    public partial class AdicionandoSessaoeevolucao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sessao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdAvaliacao = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    DataSessao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessao_Avaliacao_IdAvaliacao",
                        column: x => x.IdAvaliacao,
                        principalTable: "Avaliacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessao_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessao_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evolucao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdSessao = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    DataSessao = table.Column<DateTime>(type: "datetime", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: true),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataEvolucao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evolucao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evolucao_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evolucao_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evolucao_Sessao_IdSessao",
                        column: x => x.IdSessao,
                        principalTable: "Sessao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evolucao_FuncionarioId",
                table: "Evolucao",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Evolucao_IdSessao",
                table: "Evolucao",
                column: "IdSessao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evolucao_PacienteId",
                table: "Evolucao",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_IdAvaliacao",
                table: "Sessao",
                column: "IdAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_IdFuncionario",
                table: "Sessao",
                column: "IdFuncionario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_IdPaciente",
                table: "Sessao",
                column: "IdPaciente",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evolucao");

            migrationBuilder.DropTable(
                name: "Sessao");
        }
    }
}
