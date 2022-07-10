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

			modelBuilder.Entity<Avaliacao>()
				.HasOne(avaliacao => avaliacao.Funcionario)
				.WithMany(funcionario => funcionario.Avaliacoes)
				.HasForeignKey(avaliacao => avaliacao.IdFuncionario);

			modelBuilder.Entity<Avaliacao>()
				.HasOne(avaliacao => avaliacao.Medico)
				.WithMany(medico => medico.Avaliacoes)
				.HasForeignKey(avaliacao => avaliacao.IdMedico);

			modelBuilder.Entity<Paciente>()
				.HasOne(paciente => paciente.Avaliacao)
				.WithOne(avaliacao => avaliacao.Paciente)
				.HasForeignKey<Avaliacao>(avaliacao => avaliacao.IdPaciente);

			modelBuilder.Entity<Sessao>()
				.HasOne(sessao => sessao.Avaliacao)
				.WithMany(avaliacao => avaliacao.Sessoes)
				.HasForeignKey(sessao => sessao.IdAvaliacao);

			modelBuilder.Entity<Paciente>()
				.HasOne(paciente => paciente.Sessao)
				.WithOne(sessao => sessao.Paciente)
				.HasForeignKey<Sessao>(sessao => sessao.IdPaciente);

			modelBuilder.Entity<Funcionario>()
				.HasOne(funcionario => funcionario.Sessao)
				.WithOne(sessao => sessao.Funcionario)
				.HasForeignKey<Sessao>(sessao => sessao.IdFuncionario);

			modelBuilder.Entity<Sessao>()
				.HasOne(sessao => sessao.Evolucao)
				.WithOne(evolucao => evolucao.Sessao)
				.HasForeignKey<Evolucao>(evolucao => evolucao.IdSessao);
		}

		public DbSet<Funcionario> Funcionario { get; set; }
		public DbSet<Paciente> Pacientes { get; set; }
		public DbSet<Agendamento> Agendamento { get; set; }
		public DbSet<Avaliacao> Avaliacao { get; set; }
		public DbSet<Medico> Medico { get; set; }
		public DbSet<Sessao> Sessao { get; set; }
		public DbSet<Evolucao> Evolucao { get; set; }
		
	}
}
