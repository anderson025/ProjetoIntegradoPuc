using ClinicaFisioterapia.Context.Dtos.Agendamento;
using ClinicaFisioterapia.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public interface IAgendamentoService {		

		Task<ExibeAgendamentoDTO> BuscaAgendamentoPorId(Int32 id);

		Task<Agendamento> AdicionaAgendamento(AgendamentoDTO agendamentoDto);

		Task AtualizaAgendamento(Agendamento agendamento);

		Task ApagaAgendamento(Int32 id);

		Task<IEnumerable<Agendamento>> BuscaPorNomePaciente(String nomePaciente);

		Task<IEnumerable<Funcionario>> BuscaPorNomeFuncionario(String nomePaciente);

		Task<String> BuscaPorData(String data);
	}
}
