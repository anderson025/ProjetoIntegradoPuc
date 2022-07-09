using ClinicaFisioterapia.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaFisioterapia.Context {
	public class AppDbContext : DbContext{

		public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Endereco>()
				.HasOne(endereco => endereco.Funcionario)
				.WithOne(funcionario => funcionario.Endereco)
				.HasForeignKey<Funcionario>(funcionario => funcionario.EnderecoId);
				

			modelBuilder.Entity<Endereco>()
				.HasOne(endereco => endereco.Paciente)
				.WithOne(paciente => paciente.Endereco)
				.HasForeignKey<Paciente>(paciente => paciente.EnderecoId);

			modelBuilder.Entity<Agendamento>()
				.HasOne(agendamento => agendamento.Paciente)
				.WithOne(paciente => paciente.Agendamento)
				.HasForeignKey<Agendamento>(paciente => paciente.IdPaciente);

			modelBuilder.Entity<Agendamento>()
				.HasOne(agendamento => agendamento.Funcionario)
				.WithOne(funcionario => funcionario.Agendamento)
				.HasForeignKey<Agendamento>(funcionario => funcionario.IdFuncionario);
		}

		public DbSet<Funcionario> Funcionario { get; set; }
		public DbSet<Paciente> Pacientes { get; set; }
		public DbSet<Agendamento> Agendamento { get; set; }
		
	}
}
