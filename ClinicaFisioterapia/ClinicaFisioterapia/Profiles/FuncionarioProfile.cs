using AutoMapper;
using ClinicaFisioterapia.Context.Dtos.Endereco;
using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Models;

namespace ClinicaFisioterapia.Profiles {
	public class FuncionarioProfile : Profile {

		public FuncionarioProfile() {

			CreateMap<FuncionarioDTO, Funcionario>();
			CreateMap<Funcionario, ExibiFuncionarioDTO>();
			CreateMap<ExibiFuncionarioDTO, Funcionario>();
			CreateMap<ExibiFuncionarioDTO, FuncionarioDTO>();
			CreateMap<FuncionarioDTO, ExibiFuncionarioDTO>();

			CreateMap<EnderecoDTO, Endereco>();
			CreateMap<Endereco, EnderecoDTO>();
			CreateMap<Endereco, ExibiFuncionarioDTO>();
			CreateMap<ExibiFuncionarioDTO, Endereco>();

		}
	}
}
