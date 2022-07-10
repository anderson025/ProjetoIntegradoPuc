using ClinicaFisioterapia.Context.Dtos.Agendamento;
using ClinicaFisioterapia.Context.Dtos.Avaliacao;
using ClinicaFisioterapia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public class AvaliacaoService : IAvaliacaoService {

		public Task<Avaliacao> AdicionaAgendamento(AvaliacaoDTO avaliacaoDto) {
			throw new System.NotImplementedException();
		}

		public Task ApagaAvaliacao(int id) {
			throw new System.NotImplementedException();
		}

		public Task AtualizaAvaliacao(Avaliacao avaliacao) {
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Avaliacao>> BuscaPorData(string data) {
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Avaliacao>> BuscaPorNomeFuncionario(string nomePaciente) {
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<Avaliacao>> BuscaPorNomePaciente(string nomePaciente) {
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<ExibeAgendamentoDTO>> BuscaTodasAvaliacoes() {
			throw new System.NotImplementedException();
		}
	}
}
