using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ClinicaFisioterapia.Migrations
{
    public partial class Criacaodobancodedados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Rua = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: true),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    Uf = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

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
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Usuario = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Rg = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Celular = table.Column<string>(type: "text", nullable: false),
                    Profissao = table.Column<int>(type: "int", nullable: false),
                    Convenio = table.Column<string>(type: "text", nullable: true),
                    CarteiraConvenio = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionario_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Rg = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Celular = table.Column<string>(type: "text", nullable: false),
                    Profissao = table.Column<int>(type: "int", nullable: false),
                    Convenio = table.Column<string>(type: "text", nullable: true),
                    CarteiraConvenio = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Sessao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdAvaliacao = table.Column<int>(type: "int", nullable: false),
                    DataSessao = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
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
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataEvolucao = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evolucao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evolucao_Sessao_IdSessao",
                        column: x => x.IdSessao,
                        principalTable: "Sessao",
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

            migrationBuilder.CreateIndex(
                name: "IX_Evolucao_IdSessao",
                table: "Evolucao",
                column: "IdSessao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EnderecoId",
                table: "Funcionario",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_EnderecoId",
                table: "Pacientes",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_IdAvaliacao",
                table: "Sessao",
                column: "IdAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_IdFuncionario",
                table: "Sessao",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_IdPaciente",
                table: "Sessao",
                column: "IdPaciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Evolucao");

            migrationBuilder.DropTable(
                name: "Sessao");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
