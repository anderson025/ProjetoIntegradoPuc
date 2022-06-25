using AutoMapper;
using ClinicaFisioterapia.Context.Dtos;
using ClinicaFisioterapia.Models;

namespace ClinicaFisioterapia.Profiles {
	public class PacienteProfile : Profile{

		public PacienteProfile() {
			CreateMap<PacienteDTO, Paciente>();
			CreateMap<EnderecoDTO, Endereco>();
		}
	}
}
