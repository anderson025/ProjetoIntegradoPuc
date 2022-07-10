using AutoMapper;
using ClinicaFisioterapia.Context.Dtos.Avaliacao;
using ClinicaFisioterapia.Context.Dtos.Medico;
using ClinicaFisioterapia.Models;

namespace ClinicaFisioterapia.Profiles {
	public class MedicoProfile :Profile {

		public MedicoProfile() {

			CreateMap<Medico, MedicoDTO>();
			CreateMap<MedicoDTO, Medico>();

			CreateMap<Avaliacao, AvaliacaoDTO>();
			CreateMap<AvaliacaoDTO, Avaliacao>();

		}
	}
}
