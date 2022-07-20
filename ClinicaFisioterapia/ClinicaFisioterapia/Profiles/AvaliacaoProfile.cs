using AutoMapper;
using ClinicaFisioterapia.Context.Dtos.Avaliacao;
using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using ClinicaFisioterapia.Models;

namespace ClinicaFisioterapia.Profiles {
	public class AvaliacaoProfile : Profile {

		public AvaliacaoProfile() {

			CreateMap<Avaliacao, AvaliacaoDTO>();
			CreateMap<AvaliacaoDTO, Avaliacao>();

			CreateMap<FuncionarioDTO, Funcionario>();
			CreateMap<Funcionario, FuncionarioDTO>();
			CreateMap<Paciente, PacienteDTO>();
			CreateMap<PacienteDTO, Paciente>();

			CreateMap<Avaliacao, ExibeAvaliacaoDTO>();
			CreateMap<ExibeAvaliacaoDTO, Avaliacao>();
		}
	}
}
