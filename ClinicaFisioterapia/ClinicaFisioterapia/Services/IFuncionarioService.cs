using ClinicaFisioterapia.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public interface IFuncionarioService {

		Task<IEnumerable<Funcionario>> BuscaFuncionario();

		Task<Funcionario> BuscaFuncionarioPorId(Int32 id);

		Task AdicionaFuncionario(Funcionario funcionario);

		Task AtualizaFuncionario(Funcionario funcionario);

		Task ApagaFuncionario(Funcionario funcionario);

		Task<IEnumerable<Funcionario>> BuscaPorNome(String nome);
	}
}
