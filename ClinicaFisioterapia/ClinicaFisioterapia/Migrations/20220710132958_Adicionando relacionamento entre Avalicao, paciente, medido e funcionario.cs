using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ClinicaFisioterapia.Migrations
{
    public partial class AdicionandorelacionamentoentreAvalicaopacientemedidoefuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameMedico = table.Column<string>(type: "text", nullable: false),
                    CRM = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    IdMedico = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<double>(type: "double", nullable: false),
                    Altura = table.Column<double>(type: "double", nullable: false),
                    Diagnostico = table.Column<string>(type: "text", nullable: true),
                    MembroDominante = table.Column<int>(type: "int", nullable: false),
                    HistoricoLesao = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HistoricoLesaoDescricao = table.Column<string>(type: "text", nullable: true),
                    HMA = table.Column<string>(type: "text", nullable: true),
                    Comobirdades = table.Column<string>(type: "text", nullable: true),
                    MedicacaoEmUso = table.Column<string>(type: "text", nullable: true),
                    MedicacaoLesao = table.Column<string>(type: "text", nullable: true),
                    DormeBem = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Fuma = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ObservacaoFuma = table.Column<string>(type: "text", nullable: true),
                    Cirurgia = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ObservacaoCirurgia = table.Column<string>(type: "text", nullable: true),
                    PraticaAtividadeFisica = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ObservacaoAtividade = table.Column<string>(type: "text", nullable: true),
                    AvaliacaoPostural = table.Column<string>(type: "text", nullable: true),
                    MembrosAtivos = table.Column<string>(type: "text", nullable: true),
                    MembrosPassivos = table.Column<string>(type: "text", nullable: true),
                    TestesEspeciais = table.Column<string>(type: "text", nullable: true),
                    TestesFuncionais = table.Column<string>(type: "text", nullable: true),
                    OutrasObservacoes = table.Column<string>(type: "text", nullable: true),
                    CondutaCurtoPrazo = table.Column<string>(type: "text", nullable: true),
                    CondutaMedioPrazo = table.Column<string>(type: "text", nullable: true),
                    CondutaLongoPrazo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacao_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_IdFuncionario",
                table: "Avaliacao",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_IdMedico",
                table: "Avaliacao",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_IdPaciente",
                table: "Avaliacao",
                column: "IdPaciente",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Medico");
        }
    }
}
