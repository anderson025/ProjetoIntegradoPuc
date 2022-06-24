using ClinicaFisioterapia.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public interface IPacienteService {

		Task<IEnumerable<Paciente>> BuscaPacientes();

		Task<Paciente> BuscaPacientePorId(Int32 id);

		Task AdicionaPaciente(Paciente paciente);

		Task AtualizaPaciente(Paciente paciente);

		Task ApagaPaciente(Paciente paciente);

		Task<IEnumerable<Paciente>> BuscaPorNome(String nome);
	}
}
