using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public interface IFuncionarioService {

		Task<IEnumerable<ExibiFuncionarioDTO>> BuscaFuncionario();

		Task<Funcionario> BuscaFuncionarioPorId(Int32 id);

		Task<ExibiFuncionarioDTO> AdicionaFuncionario(FuncionarioDTO funcionarioDto);

		Task AtualizaFuncionario(Funcionario funcionario);

		Task ApagaFuncionario(Funcionario funcionario);

		Task<IEnumerable<ExibiFuncionarioDTO>> BuscaPorNome(String nome);
	}
}
