using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public interface IFuncionarioService {

		Task<IEnumerable<ExibeFuncionarioDTO>> BuscaFuncionario();

		Task<Funcionario> BuscaFuncionarioPorId(Int32 id);

		Task<ExibeFuncionarioDTO> AdicionaFuncionario(FuncionarioDTO funcionarioDto);

		Task AtualizaFuncionario(Funcionario funcionario);

		Task ApagaFuncionario(Int32 id);

		Task<IEnumerable<ExibeFuncionarioDTO>> BuscaPorNome(String nome);
	}
}
