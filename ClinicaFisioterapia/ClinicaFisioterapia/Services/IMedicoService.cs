using ClinicaFisioterapia.Context.Dtos.Medico;
using ClinicaFisioterapia.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaFisioterapia.Services {
	public interface IMedicoService {

		Task<Medico> BuscaMedicoPorId(Int32 id);

		Task<Medico> AdicionaMedico(MedicoDTO agendamentoDto);

		Task AtualizaMedico(Medico agendamento);

		Task ApagaMedico(Int32 id);

		Task<IEnumerable<Medico>> BuscaTodosMedicos();
	}
}
