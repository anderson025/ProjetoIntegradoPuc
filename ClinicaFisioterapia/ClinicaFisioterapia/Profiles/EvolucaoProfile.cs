using AutoMapper;
using ClinicaFisioterapia.Context.Dtos.Evolucao;
using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using ClinicaFisioterapia.Context.Dtos.Sessao;
using ClinicaFisioterapia.Models;

namespace ClinicaFisioterapia.Profiles {
	public class EvolucaoProfile : Profile {

		public EvolucaoProfile() {

			CreateMap<Evolucao, EvolucaoDTO>();
			CreateMap<EvolucaoDTO, Evolucao>();			

			CreateMap<Sessao, SessaoDTO>();
			CreateMap<SessaoDTO, Sessao>();

			CreateMap<Evolucao, ExibeEvolucaoDTO>();
			CreateMap<ExibeEvolucaoDTO, Evolucao>();
			
			
			
		}
	}
}
