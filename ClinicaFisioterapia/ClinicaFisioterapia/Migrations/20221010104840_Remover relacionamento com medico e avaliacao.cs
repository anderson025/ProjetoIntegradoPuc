using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaFisioterapia.Migrations
{
    public partial class Removerrelacionamentocommedicoeavaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_Medico_IdMedico",
                table: "Avaliacao");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacao_IdMedico",
                table: "Avaliacao");

            migrationBuilder.DropColumn(
                name: "IdMedico",
                table: "Avaliacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMedico",
                table: "Avaliacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_IdMedico",
                table: "Avaliacao",
                column: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Medico_IdMedico",
                table: "Avaliacao",
                column: "IdMedico",
                principalTable: "Medico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
