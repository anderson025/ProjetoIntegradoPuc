using AutoMapper;
using ClinicaFisioterapia.Context.Dtos;
using ClinicaFisioterapia.Context.Dtos.Endereco;
using ClinicaFisioterapia.Context.Dtos.Paciente;
using ClinicaFisioterapia.Models;

namespace ClinicaFisioterapia.Profiles {
	public class PacienteProfile : Profile{

		public PacienteProfile() {
			CreateMap<PacienteDTO, Paciente>();
			CreateMap<EnderecoDTO, Endereco>();
		}
	}
}
