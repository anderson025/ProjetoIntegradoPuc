using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaFisioterapia.Migrations
{
    public partial class Ajustandonomefuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeFunciorio",
                table: "Agendamento",
                newName: "NomeFuncionario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomeFuncionario",
                table: "Agendamento",
                newName: "NomeFunciorio");
        }
    }
}
