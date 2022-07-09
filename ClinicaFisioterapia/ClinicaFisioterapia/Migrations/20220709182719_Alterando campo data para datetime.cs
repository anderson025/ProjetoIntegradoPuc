using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaFisioterapia.Migrations
{
    public partial class Alterandocampodataparadatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAgendamento",
                table: "Agendamento",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataAgendamento",
                table: "Agendamento",
                type: "text",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
