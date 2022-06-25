using AutoMapper;
using ClinicaFisioterapia.Context.Dtos;
using ClinicaFisioterapia.Models;

namespace ClinicaFisioterapia.Profiles {
	public class FuncionarioProfile : Profile {

		public FuncionarioProfile() {

			CreateMap<FuncionarioDTO, Funcionario>();
			CreateMap<EnderecoDTO, Endereco>();
		}
	}
}
