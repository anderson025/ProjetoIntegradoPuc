using ClinicaFisioterapia.Context.Dtos.Agendamento;
using ClinicaFisioterapia.Context.Dtos.Avaliacao;
using ClinicaFisioterapia.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public interface IAvaliacaoService {

		Task<ExibeAvaliacaoDTO> BuscaAvaliacaoPorId(Int32 id);

		Task<ExibeAvaliacaoDTO> AdicionaAvaliacao(AvaliacaoDTO avaliacaoDto);

		Task ApagaAvaliacao(Int32 id);

		Task AtualizaAvaliacao(Avaliacao avaliacao);

		Task<IEnumerable<Avaliacao>> BuscaPorData(String data);

		Task<IEnumerable<ExibeAgendamentoDTO>> BuscaTodasAvaliacoes();

		Task<IEnumerable<Avaliacao>> BuscaPorNomePaciente(String nomePaciente);

		Task<IEnumerable<Avaliacao>> BuscaPorNomeFuncionario(String nomeFuncionario);
	}
}
