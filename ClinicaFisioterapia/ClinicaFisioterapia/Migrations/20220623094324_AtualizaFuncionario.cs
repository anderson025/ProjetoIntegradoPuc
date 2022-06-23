using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaFisioterapia.Migrations
{
    public partial class AtualizaFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Funcionario",
                type: "text",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Funcionario");
        }
    }
}
