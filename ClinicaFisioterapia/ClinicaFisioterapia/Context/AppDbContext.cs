using ClinicaFisioterapia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicaFisioterapia.Context {
	public class AppDbContext : IdentityDbContext<IdentityUser>{

		public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {

			base.OnModelCreating(modelBuilder);

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
				.WithMany(funcionario => funcionario.Agendamentos)
				.HasForeignKey(funcionario => funcionario.IdFuncionario);

			modelBuilder.Entity<Agendamento>()
				.HasOne(agendamento => agendamento.Avaliacao)
				.WithOne(avaliacao => avaliacao.Agendamento)
				.HasForeignKey<Agendamento>(avaliacao => avaliacao.IdAgendamento);

			modelBuilder.Entity<Avaliacao>()
				.HasOne(avaliacao => avaliacao.Funcionario)
				.WithMany(funcionario => funcionario.Avaliacoes)
				.HasForeignKey(avaliacao => avaliacao.IdFuncionario);

			//modelBuilder.Entity<Avaliacao>()
			//	.HasOne(avaliacao => avaliacao.Medico)
			//	.WithMany(medico => medico.Avaliacoes)
			//	.HasForeignKey(avaliacao => avaliacao.IdMedico);

			modelBuilder.Entity<Paciente>()
				.HasOne(paciente => paciente.Avaliacao)
				.WithOne(avaliacao => avaliacao.Paciente)
				.HasForeignKey<Avaliacao>(avaliacao => avaliacao.IdPaciente);

			modelBuilder.Entity<Sessao>()
				.HasOne(sessao => sessao.Avaliacao)
				.WithMany(avaliacao => avaliacao.Sessoes)
				.HasForeignKey(sessao => sessao.IdAvaliacao);

			
			modelBuilder.Entity<Sessao>()
				.HasOne(sessao => sessao.Paciente)
				.WithMany(paciente => paciente.Sessoes)
				.HasForeignKey(sessao => sessao.IdPaciente);

			modelBuilder.Entity<Sessao>()
				.HasOne(sessao => sessao.Funcionario)
				.WithMany(funcionario => funcionario.Sessoes)
				.HasForeignKey(sessao => sessao.IdFuncionario);

			//modelBuilder.Entity<Paciente>()
			//	.HasOne(paciente => paciente.Evolucao)
			//	.WithMany(evolucao => evolucao.Paciente)
			//	.HasForeignKey(paciente => paciente.IdEvolucaoPaciente);

			//modelBuilder.Entity<Funcionario>()
			//	.HasOne(funcionario => funcionario.Evolucao)
			//	.WithMany(evolucao => evolucao.Funcionario)
			//	.HasForeignKey(funcionario => funcionario.IdEvolucaoFuncionario);

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
