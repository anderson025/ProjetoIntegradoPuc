using AutoMapper;
using ClinicaFisioterapia.Context.Dtos.Evolucao;
using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using ClinicaFisioterapia.Context.Dtos.Sessao;
using ClinicaFisioterapia.Models;

namespace ClinicaFisioterapia.Profiles {
	public class SessaoProfile : Profile{
		public SessaoProfile() {

			CreateMap<Sessao, SessaoDTO>();
			CreateMap<SessaoDTO, Sessao>();

			CreateMap<Funcionario, FuncionarioDTO>();
			CreateMap<FuncionarioDTO, Funcionario>();

			CreateMap<Paciente, PacienteDTO>();
			CreateMap<PacienteDTO, Paciente>();

			CreateMap<Evolucao, EvolucaoDTO>();
			CreateMap<EvolucaoDTO, Evolucao>();

		}
	}
}
