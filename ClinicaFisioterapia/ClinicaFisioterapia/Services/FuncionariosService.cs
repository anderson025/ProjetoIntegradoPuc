using ClinicaFisioterapia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public class FuncionariosService : IFuncionarioService {

		public Task AdicionaFuncionario(Funcionario funcionario) {
			throw new System.NotImplementedException();
		}

		public Task ApagaFuncionario(int id) {
			throw new System.NotImplementedException();
		}

		public Task AtualizaFuncionario(int id, Funcionario funcionario) {
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Funcionario>> BuscaFuncionario() {
			throw new System.NotImplementedException();
		}

		public Task<Funcionario> BuscaFuncionarioPorId(int id) {
			throw new System.NotImplementedException();
		}
	}
}
