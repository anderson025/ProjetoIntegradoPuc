using ClinicaFisioterapia.Context.Dtos.Evolucao;
using ClinicaFisioterapia.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public interface IEvolucaoService {

		Task<Evolucao> BuscaEvolucaoPorId(Int32 id);

		Task<Evolucao> AdicionaEvolucao(EvolucaoDTO evolucaoDto);

		Task ApagaEvolucao(Int32 id);

		Task AtualizaEvolucao(Evolucao evolucao);

		Task<IEnumerable<Evolucao>> BuscaPorData(String data);

		Task<IEnumerable<Evolucao>> BuscaTodasEvolucoes();

		Task<IEnumerable<Evolucao>> BuscaPorNomePaciente(String nomePaciente);

		Task<IEnumerable<Evolucao>> BuscaPorNomeFuncionario(String nomeFuncionario);
	}
}
