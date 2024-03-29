﻿using AutoMapper;
using ClinicaFisioterapia.Context.Dtos.Endereco;
using ClinicaFisioterapia.Context.Dtos.Funcionario;
using ClinicaFisioterapia.Models;

namespace ClinicaFisioterapia.Profiles {
	public class FuncionarioProfile : Profile {

		public FuncionarioProfile() {

			CreateMap<FuncionarioDTO, Funcionario>();
			CreateMap<Funcionario, ExibeFuncionarioDTO>();
			CreateMap<ExibeFuncionarioDTO, Funcionario>();
			CreateMap<ExibeFuncionarioDTO, FuncionarioDTO>();
			CreateMap<FuncionarioDTO, ExibeFuncionarioDTO>();

			CreateMap<EnderecoDTO, Endereco>();
			CreateMap<Endereco, EnderecoDTO>();
			CreateMap<Endereco, ExibeFuncionarioDTO>();
			CreateMap<ExibeFuncionarioDTO, Endereco>();

		}
	}
}
