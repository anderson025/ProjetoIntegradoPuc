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
		}

		public DbSet<Funcionario> Funcionario { get; set; }
	}
}
