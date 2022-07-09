using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ClinicaFisioterapia.Migrations
{
    public partial class Criacaodeagendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    IdAgendamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    DataAgendamento = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.IdAgendamento);
                    table.ForeignKey(
                        name: "FK_Agendamento_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdFuncionario",
                table: "Agendamento",
                column: "IdFuncionario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdPaciente",
                table: "Agendamento",
                column: "IdPaciente",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");
        }
    }
}
