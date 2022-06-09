using ClinicaFisioterapia.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public interface IFuncionarioService {

		Task<IEnumerable<Funcionario>> GetFuncionario();
	}
}
