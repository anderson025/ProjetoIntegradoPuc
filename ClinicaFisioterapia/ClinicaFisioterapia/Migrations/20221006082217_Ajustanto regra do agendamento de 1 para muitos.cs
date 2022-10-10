using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaFisioterapia.Migrations
{
    public partial class Ajustantoregradoagendamentode1paramuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agendamento_IdFuncionario",
                table: "Agendamento");

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Pacientes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Funcionario",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "AgendamentoIdAgendamento",
                table: "Funcionario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_AgendamentoIdAgendamento",
                table: "Funcionario",
                column: "AgendamentoIdAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdFuncionario",
                table: "Agendamento",
                column: "IdFuncionario");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Agendamento_AgendamentoIdAgendamento",
                table: "Funcionario",
                column: "AgendamentoIdAgendamento",
                principalTable: "Agendamento",
                principalColumn: "IdAgendamento",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Agendamento_AgendamentoIdAgendamento",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_AgendamentoIdAgendamento",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_IdFuncionario",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "AgendamentoIdAgendamento",
                table: "Funcionario");

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Pacientes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Funcionario",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdFuncionario",
                table: "Agendamento",
                column: "IdFuncionario",
                unique: true);
        }
    }
}
