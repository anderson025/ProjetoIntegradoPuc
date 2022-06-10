using ClinicaFisioterapia.Context;
using ClinicaFisioterapia.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public class FuncionariosService : IFuncionarioService {

		private readonly AppDbContext _context;

		public FuncionariosService(AppDbContext context) {
			_context = context;
		}
			
		public async Task AdicionaFuncionario(Funcionario funcionario) {
			_context.Funcionario.Add(funcionario);
			await _context.SaveChangesAsync();
		}

		public async Task ApagaFuncionario(Funcionario funcionario) {
			_context.Funcionario.Remove(funcionario);
			await _context.SaveChangesAsync();
		}

		public async Task AtualizaFuncionario(Funcionario funcionario) {
			_context.Entry(funcionario).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Funcionario>> BuscaFuncionario() {
			try {
				return await _context.Funcionario.ToListAsync();
			}
			catch  {

				throw;
			}
			
		}

		public async Task<Funcionario> BuscaFuncionarioPorId(int id) {
			var funcionario = await _context.Funcionario.FindAsync(id);
			return funcionario;
		}

		public async Task<IEnumerable<Funcionario>> BuscaPorNome(string nome) {
			IEnumerable<Funcionario> funcionarios;

			if (!string.IsNullOrWhiteSpace(nome)) {
				funcionarios = await _context.Funcionario.Where(n => n.Nome.Contains(nome)).ToListAsync();
			}
			else {
				funcionarios = await BuscaFuncionario();
			}

			return funcionarios;
		}
	}
}
