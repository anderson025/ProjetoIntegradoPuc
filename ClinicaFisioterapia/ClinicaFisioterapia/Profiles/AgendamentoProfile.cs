using AutoMapper;
using ClinicaFisioterapia.Context.Dtos.Agendamento;
using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using ClinicaFisioterapia.Models;

namespace ClinicaFisioterapia.Profiles {
	public class AgendamentoProfile : Profile {

		public AgendamentoProfile() {

			CreateMap<Agendamento, AgendamentoDTO>();
			CreateMap<AgendamentoDTO, Agendamento>();
			CreateMap<Agendamento, ExibeAgendamentoDTO>();
			CreateMap<ExibeAgendamentoDTO, Agendamento>();
			CreateMap<ExibeAgendamentoDTO, AgendamentoDTO>();
			CreateMap<AgendamentoDTO, ExibeAgendamentoDTO>();

			CreateMap<FuncionarioDTO, Funcionario>();
			CreateMap<Funcionario, FuncionarioDTO>();
			CreateMap<Paciente, PacienteDTO>();
			CreateMap<PacienteDTO, Paciente>();
		}
	}
}
